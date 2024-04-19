using AspNetCore_MVC.Models.Sections;
using AspNetCore_MVC.Models.Views;
using AspNetCore_MVC.ViewModels.Sub;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AspNetCore_MVC.Controllers;

public class HomeController (HttpClient httpClient) : Controller
{
    private readonly HttpClient _httpClient = httpClient;
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

    public IActionResult Home()
    {

        return View();
    }

    [HttpPost]

    public async Task<IActionResult> Subscribe(SubscribeViewModel model)
    {
        if (ModelState.IsValid)
        {
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7216/api/subscribe", content);
            if (response.IsSuccessStatusCode)
            {
                TempData["StatusMessage"] = "You are nor subscrided";
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                TempData["StatusMessage"] = "You are nor subscrided";
            }
        }
        else
        {
            TempData["StatusMessage"] = "Invalid email address";

        }
        return RedirectToAction("Index", "Home", "subscribe");
    }
}
