using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppDJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppDJ.Data
{
    public class Shopingcontex : IdentityDbContext<ApplicationUser>
    {



        public Shopingcontex(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }



        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
     
        public DbSet<CategoryToproduct> CategoryToproducts { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> orderdetails { get; set; }
        public DbSet<InformationUser> informationUsers { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<ShowInfo> showInfos { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {


            builder.Entity<CategoryToproduct>().HasKey(P => new { P.ProductId, P.CategoryId });

            builder.Entity<Category>().HasData(new Category()
            {

                Id = 1,
                Name = "ورزشی",
                Description = "لوازم ورزشی",


            },
       new Category()  
       {


    Id = 2,
        Name = "لباس",
        Description = "انواع لباس ها",

        
            });




            builder.Entity<Product>().HasData(new Product()
            {

                Id = 1,
                Name = "کفش اسپورت",
                Description = "کفش های اسپرت المانی با تنوع ونگ های بسیار عالی",
                Price=200000,
                

            },
 new Product()
 {


     Id = 2,
     Name = " شلوار کتان",
     Description = "کفش های اسپرت المانی با تنوع ونگ های بسیار عالی",
     Price = 158000,


 });











            base.OnModelCreating(builder);
    }

        public DbSet<ShoppDJ.Models.RegisterViewModel> RegisterViewModel { get; set; }










}
}
