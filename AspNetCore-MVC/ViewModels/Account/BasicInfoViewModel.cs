using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore_MVC.ViewModels.Account;

public class BasicInfoViewModel
{
    public string UserId { get; set; } = null!;

    [Required(ErrorMessage = "Invalid first name")]
    [DataType(DataType.Text)]
    [Display(Name = "First name", Prompt = "Enter your first name")]
    public string FirstName { get; set; } = null!;


    [Required(ErrorMessage = "Invalid Last name")]
    [DataType(DataType.Text)]
    [Display(Name = "Last name", Prompt = "Enter your last name")]
    public string LastName { get; set; } = null!;


    [Required(ErrorMessage = "Invalid email adress")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email", Prompt = "Enter your email")]
    public string Email { get; set; } = null!;



    [DataType(DataType.PhoneNumber)]
    [Display(Name = "Phone", Prompt = "Enter your phone ")]
    public string? Phone { get; set; }



    [DataType(DataType.MultilineText)]
    [Display(Name = "Bio", Prompt = "Add a short massege")]
    public string? Bio { get; set; }
}
