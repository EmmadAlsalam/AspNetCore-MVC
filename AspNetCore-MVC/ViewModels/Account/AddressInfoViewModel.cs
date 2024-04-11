using System.ComponentModel.DataAnnotations;

namespace AspNetCore_MVC.ViewModels.Account;

public class AddressInfoViewModel
{
    [Required(ErrorMessage = "Invalid adress")]
    [DataType(DataType.Text)]
    [Display(Name = "Address line 1", Prompt = "Enter your first Adress")]
    public string AddressLine_1 { get; set; } = null!;




    [DataType(DataType.Text)]
    [Display(Name = "Address line 2 ", Prompt = "Enter your second Address")]
    public string ?AddressLine_2 { get; set; } 



    [Required(ErrorMessage = "Invalid postal code")]
    [DataType(DataType.Text)]
    [Display(Name = "Postal code", Prompt = "Enter your Postal code ")]
    public string PostalCode { get; set; } = null!;


    [Required(ErrorMessage = "Invalid City")]
    [DataType(DataType.Text)]
    [Display(Name = "City", Prompt = "Enter your city")]
    public string City { get; set; } = null!;




}
