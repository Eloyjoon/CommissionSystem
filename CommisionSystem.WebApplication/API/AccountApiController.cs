using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CommisionSystem.WebApplication.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommisionSystem.WebApplication.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountApiController : ControllerBase
    {
        private readonly Services.Interfaces.IUserService _userService;

        public AccountApiController(Services.Interfaces.IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var user = await _userService.GetUser(loginModel.UserName, loginModel.Password);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.FirstName));
            identity.AddClaim(new Claim(ClaimTypes.Surname, user.LastName));
            identity.AddClaim(new Claim(ClaimTypes.Role, user.Role.ID.ToString()));
            identity.AddClaim(new Claim("RoleName", user.Role.RoleName));
            identity.AddClaim(new Claim("HasAccessToProductSearchReport", user.HasAccessToProductSearchReport.ToString()));


            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return Ok();

        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return Ok();
        }

        [HttpGet("Users")]
        
        public async Task<IActionResult> ListOfUsers()
        {
            var result = await _userService.ListOfUsers();

            return Ok(result);
        }
    }
}
