using System.ComponentModel.DataAnnotations;

namespace EkartWebApp.Models
{
    public class LoginVM
    {
        // you can put all the validation here
        [Display(Name = "Enter your Email Id")]
        [Required(ErrorMessage ="Please enter your Email ID")]
        [EmailAddress]
        public string EmailId { get; set; }

        [Display(Name ="Enter your password")]
        [Required(ErrorMessage = "Please enter your Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remeber Me")]
        public bool RememberMe { get; set; }
    }
}
