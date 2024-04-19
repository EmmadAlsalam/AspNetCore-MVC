using AspNetCore_MVC.Models.Sections;
using AspNetCore_MVC.ViewModels.Sub;

namespace AspNetCore_MVC.Models.Views;

public class HomeIndexViewModel
{
    public string Title { get; set; } = "";
    public ShowcaseViewModel Showcase { get; set; } = null!;
    public SubscribeViewModel Subscribe { get; set; } = null!;



}
