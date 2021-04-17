using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppDJ.Models
{
    public class ShowInfo
    {


        public int Id { get; set; }
        public string UserName { get; set; }



       
        public string FirstName { get; set; }
   
        public string LastName { get; set; }
      
        public string PhoneNumber { get; set; }
     
        public string Email { get; set; }


       
        public string Adress { get; set; }

      
        public string Address2 { get; set; }
      
        public string City { get; set; }
       
        public string NumberCodepos { get; set; }
       
        public string Country { get; set; }



    }
}
