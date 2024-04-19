using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entites;

public class UserEntity : IdentityUser

{
    [ProtectedPersonalData]

    public string FirstName { get; set; } = null!;


    [ProtectedPersonalData]
    public string LastName { get; set; } = null!;

    public string? ProfileImage { get; set; } = "avatar.jpg";

    [ProtectedPersonalData]
    public int? AddressId { get; set; }
    public AddressEntity? Address { get; set; }
    [ProtectedPersonalData]
    public string? Bio { get; set; }


}
