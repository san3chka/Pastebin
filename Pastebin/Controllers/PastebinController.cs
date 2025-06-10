using Microsoft.AspNetCore.Mvc;
using Pastebin.Models;
using Pastebin.Services.Auth;
using Pastebin.Services.Post;
using Persistence.Entity;

namespace Pastebin.Controllers;


[ApiController]
[Route("api/[controller]")]
public class PastebinController(IAuthService authService, IPasteService pasteService) : ControllerBase
{
   [HttpPost("register")]
   public async Task<ActionResult<User>> Register(UserDto request)
   {
      var user = await authService.RegisterAsync(request);
      if (user is null)
         return BadRequest("username is already exists");

      return Ok(user);
   }

   [HttpPost("login")]
   public async Task<ActionResult<string>> Login(UserDto request)
   {
      var result = await authService.LoginAsync(request);

      if (result is null)
         return BadRequest("invalid username or password");

      return Ok("success");
   }

   [HttpPost("paste")]
   public async Task<ActionResult> Paste(PasteDto request)
   {
      var result = await pasteService.PasteAsync(request);

      if (result is null)
      {
         return BadRequest("paste must be <10");
      }

      return Ok(result);
   }
}