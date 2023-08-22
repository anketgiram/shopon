using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoponWebApp.Models
{
    public class RegisterViewModel
    {
        [Display(Name ="Enter Email ID")]
        [Required(ErrorMessage ="Email ID cannot be blank")]
        [EmailAddress]
        public string  LoginId { get; set; }

        [Display(Name ="Enter the Mobile Number")]
        [Required(ErrorMessage ="Mobile Number cannot be blank")]
        //[DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Please Enter Valid Mobile Number")]
        public string MobileNumber { get; set; }

        [Display(Name ="Enter the First name and Last Name")]
        [Required(ErrorMessage ="Name cannot be blank")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Display(Name ="Enter Password")]
        [Required(ErrorMessage ="Password cannot be blank")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Enter Confirm Password")]
        [Required(ErrorMessage = "Confirm Password cannot be blank")]
        [Compare("Password",ErrorMessage ="Confirm Password does not match with password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
