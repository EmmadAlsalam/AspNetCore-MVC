using System.ComponentModel.DataAnnotations;

namespace AspNetCore_MVC.Models
{
    public class SignInModel
    {
        [Display(Name = "Email Adress", Prompt = "Enter you email adress")]
        [Required(ErrorMessage = "Invalid Email adress")]
        public string Email { get; set; } = null!;


        [Display(Name = "Password", Prompt = "Enter you password")]
        [Required(ErrorMessage = "Invalid Password")]
        public string Password { get; set; } = null!;
        [DataType(DataType.Password)]


        [Display(Name = "Remember me")]

        public bool RememberMe { get; set; } = false;
    }
}
