using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShoppDJ.Data;
using ShoppDJ.Data.Repository;
using ShoppDJ.Models;
using ShoppDJ.Security;
using ShoppDJ.Security.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppDJ
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
                
            services.AddRazorPages();
           
            #region Db Contex

            services.AddDbContext<Shopingcontex>(option =>
            {
                option.UseSqlServer("Data Source=.;Initial Catalog=DjShop_;   Integrated Security = true");


            }

                );
            #endregion

            services.Configure<PhoneTotpOptions>(options =>
            {
                options.StepInSeconds = 30;
            });

            services.AddAuthentication()
                    .AddGoogle(options =>
                    {
                        options.ClientId = "457993417792-hui925cb3oul7qjonqpm6junjp9in28b.apps.googleusercontent.com";
                        options.ClientSecret = "QA-KOp05nRjW9LA-D-yNODad";
                    });
                services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                //options.Password.RequiredUniqueChars = 0;
                options.SignIn.RequireConfirmedPhoneNumber = true;
                options.User.RequireUniqueEmail = false;
               
                //options.User.AllowedUserNameCharacters =
                    //"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-";

                //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
            })
                .AddEntityFrameworkStores<Shopingcontex>()
                .AddDefaultTokenProviders();
            //.AddErrorDescriber<PersianIdentityErrorDescriber>();
            services.AddScoped<IMessageSender, MessageSender>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPhoneTotpProvider,PhoneTotpProvider>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
