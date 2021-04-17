using Microsoft.AspNetCore.Mvc;
using ShoppDJ.Data;
using ShoppDJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppDJ.Controllers
{
    public class Information : Controller
    {
        private readonly Shopingcontex _contex;
        public Information(Shopingcontex contex)
        {
            _contex = contex;
        }

        public IActionResult Info(string Emaile)
        {
            var User = _contex.informationUsers.ToList();

            if(! ModelState.IsValid)
            {

                return View();

            }
            var Info = _contex.showInfos.FirstOrDefault(o => o.Email == Emaile);

          var Information = new InformationUser()
            {    UserName=Info.UserName,    
                FirstName=Info.FirstName,
                LastName=Info.LastName,
                City=Info.City,
                Adress= Info.Adress,
                Address2= Info.Address2,
                Country="Iran",
                PhoneNumber= Info.PhoneNumber,
                Email= Info.Email,
                NumberCodepos= Info.NumberCodepos,
                


          };
            _contex.informationUsers.Add(Information);
            _contex.SaveChanges();
            return View();
        }
    }
}
