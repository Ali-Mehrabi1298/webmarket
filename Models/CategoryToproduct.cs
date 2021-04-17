using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppDJ.Models
{
    public class CategoryToproduct
    {


        public int ProductId  { get; set; }

        public int CategoryId { get; set; }

     
        public Product product { get; set; }
        public Category Category { get; set; }

       
    }
}
