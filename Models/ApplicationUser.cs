using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppDJ.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string codeconfig { get; set; }

        public DateTime DateTime { get; set; }


    }
}

