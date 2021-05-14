using Microsoft.AspNetCore.Identity;
using ShoppDJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppDJ.Data.Repository
{
   public interface IUserRepository
    {

        ApplicationUser GetUserForLogin(string Email, string password);

    }

    public class UserRepository : IUserRepository
    {

        private Shopingcontex _shopingcontex;

        public UserRepository(Shopingcontex shopingcontex)
        {
            _shopingcontex = shopingcontex;
        }

        public ApplicationUser GetUserForLogin(string Email, string password)
        {
           return _shopingcontex.Users.Single(d=>d.Email==Email &&  d.PasswordHash==password);
        }





    }
}
