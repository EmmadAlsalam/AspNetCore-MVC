using AspNetCore_MVC.Models.Sections;

namespace AspNetCore_MVC.Models.Views;

public class HomeIndexViewModel
{
    public string Title { get; set; } = "";
    public ShowcaseViewModel Showcase { get; set; } = null!;



}
