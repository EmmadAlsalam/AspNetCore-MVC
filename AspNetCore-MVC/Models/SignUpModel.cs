using System.ComponentModel.DataAnnotations;

namespace AspNetCore_MVC.Models
{
    public class SignUpModel
    {
        [Display(Name = "First name", Prompt = "Enter your first name", Order = 0)]
        [Required(ErrorMessage = "Invalid first  name")]
        public string FirstName { get; set; } = null!;


        [Display(Name = "Last name", Prompt = "Enter your last name", Order = 1)]
        [Required(ErrorMessage = "Invalid last  name")]
        public string LastName { get; set; } = null!;


        [Display(Name = "Email address", Prompt = "Enter your email address", Order = 2)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Invalid email address")]
        [RegularExpression("^[^@\\s]+@[^@\\s]+\\.[^@\\s]{2,}$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = null!;


        [Display(Name = "Password", Prompt = "Enter your password", Order = 3)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Invalid password ")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[!@#$%^&*()_+{}\\[\\]:;<>,.?/\\|]).{8,}$", ErrorMessage = "Invalid password.")]
        public string Password { get; set; } = null!;


        [Display(Name = "Confirm password", Prompt = "Confirm your password", Order = 4)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password must be confirmed")]
        [Compare(nameof(Password), ErrorMessage = "Password does not match")]
        public string ConfirmPassword { get; set; } = null!;


        [Display(Name = "I agree to the Terms & Conditions", Order = 5)]
        [Required(ErrorMessage = "You must accept the terms and condtions")]
        public bool TermsAndConditions { get; set; } = false;

    }

}


