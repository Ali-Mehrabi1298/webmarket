using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShoppDJ.Data;
using ShoppDJ.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ZarinpalSandbox;

namespace ShoppDJ.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Shopingcontex _shopingcontex;
        public HomeController(ILogger<HomeController> logger, Shopingcontex shopingcontex)
        {
            _logger = logger;
            _shopingcontex = shopingcontex;

        }

        public IActionResult Index()
        {

            var News = _shopingcontex.News.ToList();

            var product = _shopingcontex.products.ToList();

            //var userId = /*int.Parse*/(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var order = _shopingcontex.orders.Where(o => o.username == User.Identity.Name && !o.IsFinaly)
                .Include(o => o.OrderDetails)
                .ThenInclude(c => c.Product).FirstOrDefault();

            var productss = _shopingcontex.CategoryToproducts.Where(c => c.CategoryId == 1)
            .Include(d => d.product).Select(s => s.product).OrderByDescending(n => n).Take(6).ToList();

            //var categorytoproduct = _shopingcontex.CategoryToproducts.Where(p => p.Number == 1 || p.Number == 2).ToList();


            var Indexx = new Indexx
            {

                products = productss,
                News = News,
                orders = order,
                //categoryToproducts=categorytoproduct

            };


            return View(Indexx);
        }



        public async Task<IActionResult> Search(string searchString)
        {
            var product = from m in _shopingcontex.products
                          select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                product = product.Where(s => s.Name.Contains(searchString));
            }

            return View(await product.ToListAsync());
        }





        public IActionResult Detail(int id)
        {


            var product = _shopingcontex.products.SingleOrDefault(p => p.Id == id);

            var Detail = new DetailsViewModel
            {

                Product = product

            };




            return View(Detail);
        }



        [Authorize]
        public IActionResult AddToCart(int itemId)
        {



            var product = _shopingcontex.products.SingleOrDefault(p => p.ItemId == itemId);
            if (product != null)
            {
                //var userId = /*int.Parse*/(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
                //var userId = _shopingcontex.Users.Where(p=>p.Id==);



                var order = _shopingcontex.orders.FirstOrDefault(o => o.username == User.Identity.Name && !o.IsFinaly);
                if (order != null)
                {
                    var orderDetail =
                        _shopingcontex.orderdetails.FirstOrDefault(d =>
                            d.OrderId == order.OrderId && d.ProductId == product.Id);
                    if (orderDetail != null)
                    {
                        orderDetail.Count += 1;
                    }
                    else
                    {
                        _shopingcontex.orderdetails.Add(new OrderDetail()
                        {
                            OrderId = order.OrderId,
                            ProductId = product.Id,
                            Price = product.Price,
                            Count = 1
                        });
                    }
                }
                else
                {



                    order = new Order()
                    {
                        IsFinaly = false,
                        dateTime = DateTime.Now,
                        username = User.Identity.Name,
                        ProductName = product.Name
                    };
                    _shopingcontex.orders.Add(order);
                    _shopingcontex.SaveChanges();
                    _shopingcontex.orderdetails.Add(new OrderDetail()
                    {
                        OrderId = order.OrderId,
                        ProductId = product.Id,

                        Price = product.Price,
                        Count = 1
                    });
                }

                _shopingcontex.SaveChanges();
            }


            return RedirectToAction("ShowCart");
        }







        [Authorize]
        public IActionResult ShowCart()
        {
            var userId = /*int.Parse*/(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var order = _shopingcontex.orders.Where(o => o.username == User.Identity.Name && !o.IsFinaly)
                .Include(o => o.OrderDetails)
                .ThenInclude(c => c.Product).FirstOrDefault();


            return View(order);
        }

        [Authorize]
        public IActionResult RemoveCart(int detailId)
        {

            var orderDetail = _shopingcontex.orderdetails.Find(detailId);
            _shopingcontex.Remove(orderDetail);
            _shopingcontex.SaveChanges();

            return RedirectToAction("ShowCart");
        }



        [Route("Group/{id}/{name}")]
        public IActionResult ShowProductByGroupId(int id, string name)
        {
            ViewData["GroupName"] = name;
            var products = _shopingcontex.CategoryToproducts
                .Where(c => c.CategoryId == id)
                .Include(c => c.product)
                .Select(c => c.product)
                .ToList();
            return View(products);
        }




        public IActionResult AboutMe()
        {
            return View();
        }

        public IActionResult contact()
        {
            return View();
        }


        public IActionResult Page404()

        {

            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }





        [Authorize]
        public IActionResult Payment()
        {
            var order = _shopingcontex.orders.SingleOrDefault(o => !o.IsFinaly);
            if (order == null)
            {
                return NotFound();
            }

            var payment = new Payment(order.OrderDetails.Count);
            var res = payment.PaymentRequest($"پرداخت فاکتور شماره {order.OrderId}",
                "https://localhost:44358/Home/OnlinePayment/" + order.OrderId, "Iman@Madaeny.com", "09197070750");
            if (res.Result.Status == 100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
            }
            else
            {
                return BadRequest();
            }

            return null;
        }
    


    public IActionResult OnlinePayment(int id)
        {
            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok" &&
                HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"].ToString();
                var order = _shopingcontex.orders.Include(o => o.OrderDetails)
                    .FirstOrDefault(o => o.OrderId == id);
                var payment = new Payment((int)order.OrderDetails.Sum(d => d.Price));
                var res = payment.Verification(authority).Result;
                if (res.Status == 100)
                {
                    order.IsFinaly = true;
                    _shopingcontex.orders.Update(order);
                    _shopingcontex.SaveChanges();
                    ViewBag.code = res.RefId;
                    return View();
                }
            }

            return NotFound();
        }

    }
}

