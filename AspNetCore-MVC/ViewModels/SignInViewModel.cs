using AspNetCore_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_MVC.ViewModels
{
    public class SignInViewModel
    {
        public string Title { get; set; } = "Sign In";

        [BindProperty]
        public SignInModel Form { get; set; } = new SignInModel();
    }
}
