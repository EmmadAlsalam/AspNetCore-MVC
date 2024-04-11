using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entites;

public class AddressEntity
{
    
    public int Id { get; set; }
    public string UserId { get; set; } = null!;
    public string StreetName { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;


    public ICollection<UserEntity> Users { get; set; } = [];
  
}
