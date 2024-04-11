using AspNetCore_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AspNetCore_MVC.ViewModels;

public class SignInViewModel
{
    [DataType(DataType.EmailAddress)]
    [DisplayName("Email adress")]
    [Required(ErrorMessage = "Invalid Email adress")]
    [RegularExpression("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Invalid email")]
    public string Email { get; set; } = null!;



    [DataType(DataType.Password)]
    [DisplayName("Password")]
    [Required(ErrorMessage = "Invalid Password")]

    public string Password { get; set; } = null!;



    public bool RememberMe { get; set; } 
}

