using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pastebin.Models;
using Persistence;
using Persistence.Entity;

namespace Pastebin.Services.Auth;

public class AuthService(PastebinContext context) : IAuthService
{
    public async Task<User?> RegisterAsync(UserDto request)
    {
        if (await context.Users.AnyAsync(u => u.Username == request.Username))
        {
            return null;
        }
        
        var user = new User();
        var hashedPassword = new PasswordHasher<User>()
            .HashPassword(user, request.Password);
        
        user.Username = request.Username;
        user.PasswordHash = hashedPassword;

        context.Users.Add(user);
        await context.SaveChangesAsync();

        return user;
    }

    public async Task<string?> LoginAsync(UserDto request)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
        if (user is null)
            return null;

        return new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, request.Password)
               == PasswordVerificationResult.Failed ? null : "успех";
    }
}