using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppDJ.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppDJ.Data.Repository
{
    public interface IGroupRepository
    {

        //public IEnumerable/*<Product>*/ GetNewproduct();


        public IEnumerable<Product> GroupSpecial();

        public IEnumerable<Product> GroupPupolation();

        public IEnumerable<ShowGroupCategory> GetGroupForShow();

    }






    public class GroupRepository : IGroupRepository
    {

        private Shopingcontex _shopingcontex;
        public GroupRepository(Shopingcontex shopingcontex)
        {
            _shopingcontex = shopingcontex;
        }





        //public IEnumerable/*<Product> GetNewproduct()
        //{



        //    //var productss = _shopingcontex.CategoryToproducts.Where(c => c.CategoryId == 1)
        //    //   .Include(d => d.product).Select(s => s.product).OrderByDescending(n => n).ToList();



        //    //var Produ = new Showproduct

        //    //{

        //    //    Product = productss

        //    //};
        //    //yield return Produ;
        //    //;

        //}

        public IEnumerable<Product> GroupPupolation()
        {
            var Group = _shopingcontex.CategoryToproducts.Where(c => c.CategoryId == 3)
               .Include(d => d.product).Select(s => s.product).OrderByDescending(n=>n).Take(4).ToList();


            return Group;

        }

        public IEnumerable<Product> GroupSpecial()
        {



            var category = _shopingcontex.CategoryToproducts.Where(c => c.CategoryId == 2)
               .Include(d => d.product).Select(s => s.product).ToList();


            return category;

            ;

        }

        public IEnumerable<ShowGroupCategory> GetGroupForShow( )
        {
            return _shopingcontex.categories
                 .Select(c => new ShowGroupCategory()
                 {
                     GroupId = c.Id,
                     Name = c.Name,
                     Count = _shopingcontex.CategoryToproducts.Count(g => g.CategoryId == c.Id)
                 }).ToList();




        }
    }
}

