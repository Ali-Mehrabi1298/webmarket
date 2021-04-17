using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppDJ.Models
{
    public class Product
    {     
        [Key]
        public int Id { get; set; }

        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Number { get; set; }




        public ICollection<CategoryToproduct> CategoryToproducts { get; set; }
       

    }
}
