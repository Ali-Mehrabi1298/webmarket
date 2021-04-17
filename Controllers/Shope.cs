using Microsoft.AspNetCore.Mvc;
using ShoppDJ.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppDJ.Controllers
{
    public class Shope : Controller
    {

        private Shopingcontex  _shopingcontex;

        public Shope(Shopingcontex shopingcontex)
        {
            _shopingcontex = shopingcontex;
        }
        public IActionResult Index()
        {

            var product = _shopingcontex.products.ToList();

            return View(product);
        }





    }
}
