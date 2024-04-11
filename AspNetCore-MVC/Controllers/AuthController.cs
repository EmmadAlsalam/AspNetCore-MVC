using AspNetCore_MVC.ViewModels;
using Infrastructure.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AspNetCore_MVC.Controllers;

public class AuthController : Controller
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly SignInManager<UserEntity> _signInManager;

    public AuthController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    #region (Sign up)
    [Route("/Signup")]
    [HttpGet]
    public IActionResult SignUp()
    {
        if (_signInManager.IsSignedIn(User))
            return RedirectToAction("Details", "Auth");
        return View();
    }

    [Route("/Signup")]
    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpViewModel viewModel)
    {
        var standardRole = "User";
        if (ModelState.IsValid)
        {
            if(!await _userManager.Users.AnyAsync())
            {
                standardRole = "Admin";
            }
            var exists = await _userManager.Users.AnyAsync(x => x.Email == viewModel.Email);
            if (exists)
            {
                ModelState.AddModelError("AlreadyExists", "User with the same email address already exists");
                ViewData["ErrorMessage"] = "User with the same email address already exists";
                return View(viewModel);
            }

            var userEntity = new UserEntity
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email = viewModel.Email,
                UserName = viewModel.Email
            };

            var result = await _userManager.CreateAsync(userEntity, viewModel.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(userEntity, standardRole);
                return RedirectToAction("SignIn", "Auth");


            }
        }
        return View(viewModel);
    }

    #endregion

    #region (Sign in)
    [HttpGet]
    [Route("/Signin")]
    public IActionResult SignIn(string returnUrl)
    {
        if (_signInManager.IsSignedIn(User))
            return RedirectToAction("Details", "Account");
        ViewData["ReturnUrl"] = returnUrl ?? Url.Content("~/");

        return View();
    }

    [HttpPost]
    [Route("/Signin")]

    //public async Task<IActionResult> SignIn(SignInViewModel viewModel, string returnUrl)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        if ((await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, viewModel.RememberMe, false)).Succeeded)
    //            return LocalRedirect(returnUrl);

    //    }

    //    ModelState.AddModelError("IncorrectValues", "Incorrect email or password");
    //    ViewData["ReturnUrl"] = returnUrl;
    //    ViewData["ErrorMessage"] = "Incorrect email or password ";

    //    return View(viewModel);
    //}

    public async Task<IActionResult> SignIn(SignInViewModel viewModel    /*, string returnUrl*/)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, viewModel.RememberMe, false);
            if (result.Succeeded)
            {
                //if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                //    return Redirect(returnUrl);

                return RedirectToAction("Details", "Account");
            }
        }

        ModelState.AddModelError("IncorrectValues", "Incorrect email or password");
        ViewData["ErrorMessage"] = "Incorrect email or password ";

        return View(viewModel);
    }


    #endregion

    #region(Sign out)

    [Route("/Signout")]
    [HttpGet]
    public new async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("SignIn", "Auth");
    }


   
    [HttpGet]
    [Route("/account/details")]
    public async Task <IActionResult>  Details()
    {
      
        if (!_signInManager.IsSignedIn(User))
            return RedirectToAction("SignIn", "Auth");
        var userEntity = await _userManager.GetUserAsync(User);

        var viewModel = new AccountViewModel()
        {
            User = userEntity!
        };

        return View(viewModel);
    }




    #endregion




}



