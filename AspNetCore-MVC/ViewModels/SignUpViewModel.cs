using AspNetCore_MVC.Models;

namespace AspNetCore_MVC.ViewModels
{
    public class SignUpViewModel
    {
        public string Title { get; set; } = "Sign up";
        public SignUpModel Form { get; set; } = new SignUpModel();
    }
}


