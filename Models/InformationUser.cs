using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppDJ.Models
{
    public class InformationUser
    {

        public int Id { get; set; }
        public string UserName { get; set; }
        [Required]
        [Display(Name = "نام ")]
        public string FirstName  { get; set; }
        [Required]
        [Display(Name = "نام خانوادگی ")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "شماره تلفن ")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "ایمیل ")]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [Display(Name = "ادرس")]
        public string  Adress { get; set; }

        [Required]
        [Display(Name = "ادرس 2")]
        public string Address2 { get; set; }
        [Required]
        [Display(Name = "نام شهر")]
        public string City { get; set; }
        [Required]
        [Display(Name = "کد پستی")]
        public string NumberCodepos { get; set; }
        [Required]
        [Display(Name = "کشور")]
        public string Country { get; set; }



    }
}
