using System.ComponentModel.DataAnnotations;

namespace AspNetCore_MVC.ViewModels.Sub;

public class SubscribeViewModel
{
    [Required]
    [EmailAddress]
    [Display(Name = "Email address", Prompt = "Your Email")]
    public string Email { get; set; } = null!;
    public bool DailyNewsletter { get; set; }
    public bool AdvertisingUpdates { get; set; }
    public bool WeekInReview { get; set; }
    public bool EventUpdates { get; set; }
    public bool StartupsWeekly { get; set; }
    public bool Podcasts { get; set; }

}
