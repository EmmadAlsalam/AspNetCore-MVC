
using AspNetCore_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_MVC.Controllers
{
    public class AuthController : Controller
    {
        [Route("/Signup")]
        [HttpGet]
        public IActionResult Signup()
        {
            var ViewModel = new SignUpViewModel();
            return View(ViewModel);
        }

        [Route("/Signup")]

        [HttpPost]
        public IActionResult SignUp (SignUpViewModel ViewModel)
        {
            if (ModelState.IsValid)
                return View(ViewModel);

            return RedirectToAction("SignIn", "Auth");
             
        }


        //[Route("/Signin")]
        //[HttpGet]
        //public IActionResult Signin()
        //{
        //    var ViewModel = new SignUpViewModel();
        //    return View(ViewModel);
        //}

        //[Route("/Signin")]

        //[HttpPost]
        //public IActionResult Signin(SignUpViewModel ViewModel)
        //{
        //    if (ModelState.IsValid)
        //        return View(ViewModel);

        //    return RedirectToAction("Signup", "Auth");

        //}
    }

}

