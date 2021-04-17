using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppDJ.Data.Repository
{
   public interface IUserRepository
    {

        IdentityUser GetUserForLogin(string Email, string password);

    }

    public class UserRepository : IUserRepository
    {

        private Shopingcontex _shopingcontex;

        public UserRepository(Shopingcontex shopingcontex)
        {
            _shopingcontex = shopingcontex;
        }

        public IdentityUser GetUserForLogin(string Email, string password)
        {
           return _shopingcontex.Users.Single(d=>d.Email==Email &&  d.PasswordHash==password);
        }
    }
}
