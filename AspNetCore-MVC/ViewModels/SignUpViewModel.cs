using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Infrastructure.Helpers;

namespace AspNetCore_MVC.ViewModels;

public class SignUpViewModel
{
    [DataType(DataType.Text)]
    [DisplayName("First name")]
    [Required(ErrorMessage = "Invalid first name")]
    [MinLength(2, ErrorMessage = "Enter a first name")]
    public string FirstName { get; set; } = null!;



    [DataType(DataType.Text)]
    [DisplayName("Lats name")]
    [Required(ErrorMessage = "Invalid Last name")]
    [MinLength(2, ErrorMessage = "Enter a LastName")]
    public string LastName { get; set; } = null!;




    [DataType(DataType.EmailAddress)]
    [DisplayName("Email adress")]
    [Required(ErrorMessage = "Invalid Email adress")]
    [RegularExpression("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Invalid email")]
    public string Email { get; set; } = null!;





    
    [DataType(DataType.Password)]
    [DisplayName("Password")]
    [Required(ErrorMessage = "Invalid Password")]

    public string Password { get; set; } = null!;
    [DataType(DataType.Password)]



    [DisplayName("Comfrim Password")]
    [Required(ErrorMessage = "must Comfrim Password")]
    [Compare(nameof(Password), ErrorMessage = "Password does not match")]
    public string ComfrimPassword { get; set; } = null!;



    [RequiredCheckbox(ErrorMessage = "Terms And conditions must be accepted")]
    public bool Terms { get; set; } = false;
}


