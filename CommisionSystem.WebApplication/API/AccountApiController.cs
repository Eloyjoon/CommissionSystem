using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CommissionSystem.Business.User;
using CommissionSystem.WebApplication.Models;
using CommissionSystem.WebApplication.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommissionSystem.WebApplication.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountApiController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountApiController(IUserService userService)
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
            identity.AddClaim(new Claim("UserID", user.ID.ToString()));
            identity.AddClaim(new Claim("FirstName", user.FirstName));
            identity.AddClaim(new Claim("LastName", user.LastName));
            identity.AddClaim(new Claim("RoleName", user.Role.Name));
            identity.AddClaim(new Claim("AccessLevel", user.Role.AccessLevel.ToString()));

            identity.AddClaim(new Claim("ExpertDashboard", ""));
            identity.AddClaim(new Claim("ReadProducts", ""));

            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return Ok();

        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return Ok();
        }

        [HttpGet("Users")]

        public async Task<IActionResult> ListOfUsers()
        {
            var result = await _userService.ListOfUsers();

            return Ok(result.Cast<ReadUserModel>());
        }
    }
}
