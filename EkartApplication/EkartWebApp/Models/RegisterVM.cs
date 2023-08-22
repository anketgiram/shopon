using System.ComponentModel.DataAnnotations;

namespace EkartWebApp.Models
{
    public class RegisterVM
    {
        // you can put all the validation here
        [Display(Name = "Enter your Email Id")]
        [Required(ErrorMessage = "Please enter your Email ID")]
        [EmailAddress]
        public string EmailId { get; set; }

        [Display(Name = "Enter your Password")]
        [Required(ErrorMessage = "Please enter your Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Enter your Confirm Password")]
        [Required(ErrorMessage = "Please enter your Confirm Password")]
        [DataType(DataType.Password)]
        //to check wether your password and confirm password is same or not 
        [Compare("Password", ErrorMessage ="Password and Confirm Password does not match")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Enter your City")]
        public string City { get; set; }

        [Display(Name = "Enter your State")]
        public string State { get; set; }

    }
}
