namespace AspNetCore_MVC.ViewModels.Account
{
    public class AccountDetailsViewModel
    {
        public ProfileInfoViewModel ProfileInfo { get; set; } = null!;
        public BasicInfoViewModel BasicInfoForm { get; set; } = null!;
        public AddressInfoViewModel AddressInfoForm { get; set; } = null!;

       
    }
}
