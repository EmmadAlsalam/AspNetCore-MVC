using AspNetCore_MVC.ViewModels.Account;
using Infrastructure.Entites;
using System.Diagnostics.Contracts;

namespace AspNetCore_MVC.ViewModels;

public class AccountViewModel
{

    public UserEntity User { get; set; } = null!;
}
