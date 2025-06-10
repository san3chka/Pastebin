using Pastebin.Models;
using Persistence.Entity;

namespace Pastebin.Services.Auth;

public interface IAuthService
{
    Task<User?> RegisterAsync(UserDto request);
    Task<string?> LoginAsync(UserDto request);
}