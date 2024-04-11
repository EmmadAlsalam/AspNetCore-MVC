using Infrastructure.Contexts;
using Infrastructure.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AccountService
{
    private readonly AppDbContext _context;
    private readonly UserManager<UserEntity> _userManager;

    public AccountService(AppDbContext context, UserManager<UserEntity> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<bool> UpdateUserAsync(UserEntity user)
    {
        var existingUser = await _userManager.FindByIdAsync(user.Id);

        if (existingUser == null)
        {
            // Användaren hittades inte
            return false;
        }

        // Uppdatera användarens egenskaper baserat på inkommande user-objekt
        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        existingUser.Email = user.Email;

        // Uppdatera användaren i databasen
        var result = await _userManager.UpdateAsync(existingUser);

        return result.Succeeded;
    }


}
