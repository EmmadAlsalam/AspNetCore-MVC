using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_MVC.Controllers;

public class DefaultController : Controller
{
    //[Route("/")]
    //public IActionResult Default() => View();

    [Route("/error")]
    public IActionResult Error404(int statusCode) => View();

    [Route("/denied")]
    public IActionResult AccessDenied(int statusCode) => View();
}