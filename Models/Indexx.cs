using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppDJ.Models
{
    public class Indexx
    {

        public int Numberslider { get; set; }
        public List <CategoryToproduct> categoryToproducts  { get; set; }
        public  IEnumerable <Product> products  { get; set; }

        public IEnumerable<News> News { get; set; }

        public Category Categories { get; set; }
        public Order orders { get; set; }
    }
}
