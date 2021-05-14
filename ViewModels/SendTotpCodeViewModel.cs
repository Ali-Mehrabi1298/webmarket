using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppDJ.ViewModels
{
    public class SendTotpCodeViewModel
    {


        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        [MaxLength(11, ErrorMessage = "حداکثر طول مجاز {0} {1} کاراکتر است.")]
        [Phone]
        public string PhoneNumber { get; set; }




        [Required]
        [Display(Name = "رمزعبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        ////[Required]
        ////[Display(Name = "تکرار رمزعبور")]
        ////[Compare(nameof(Password))]
        ////[DataType(DataType.Password)]
        ////public string ConfirmPassword { get; set; }


        

        //public string code { get; set; }





    }
}
