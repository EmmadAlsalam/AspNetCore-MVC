using AspNetCore_MVC.Models.Sections;
using AspNetCore_MVC.Models.Views;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_MVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
       
        ViewData["Title"] = "Task Management Assistant";
        var viewModel = new HomeIndexViewModel
        {
            Title = "Task Management Assistant",
            Showcase = new ShowcaseViewModel
            {
                Id = "overview",
                ShowcaseImage = new() { ImageUrl = "images/showcase.svg", AltText = "Tasj Management Assistant" },
                Title = "Task Management Assistant You Gonna Love",
                Text = "We offer you a new generation of task management system. Plan, manage & track all your tasks in one flexible tool.",
                Link = new() { ControllerName = "DownLoads", ActionName = "Index", Text= "Ger started for free" },
                BrandsText = "Largest companies use our tool to work efficiently",
                Brands = 
                [
                    new() { ImageUrl = "images/brand_1.svg", AltText = "Brand 1" },
                    new() { ImageUrl = "images/brand_2.svg", AltText = "Brand 2" },
                    new() { ImageUrl = "images/brand_3.svg", AltText = "Brand 3" },
                    new() { ImageUrl = "images/brand_4.svg", AltText = "Brand 4" },
                ]
            }
        };
       

        return View(viewModel);
    }
}
