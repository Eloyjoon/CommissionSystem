using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CommisionSystem.WebApplication.Models;
using CommisionSystem.WebApplication.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CommisionSystem.WebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly Services.Interfaces.IUserService _userService;

        public AccountController(Services.Interfaces.IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var user = await _userService.GetUser(loginModel.UserName,loginModel.Password);
            if (user == null)
            {
                ModelState.AddModelError("", "User not found");
                return View(loginModel);
            }
            if (!user.Status)
            {
                ModelState.AddModelError("", "Account is disabled. Call the admin.");
                return View(loginModel);
            }

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.FirstName));
            identity.AddClaim(new Claim(ClaimTypes.Surname, user.LastName));
            identity.AddClaim(new Claim("RoleName", user.Role.RoleName));
            identity.AddClaim(new Claim("AccessLevel", user.Role.AccessLevel.ToString()));


            identity.AddClaim(new Claim("ExpertDashboard", ""));
            identity.AddClaim(new Claim("ReadProducts",""));
            

            identity.AddClaim(new Claim("HasAccessToProductSearchReport", user.HasAccessToProductSearchReport.ToString()));


            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            if(string.IsNullOrEmpty(loginModel.ReturnUrl))
                return RedirectToAction("Expert", "Dashboard");
            else
                return Redirect(loginModel.ReturnUrl);            
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateUser()
        {
            var roles = (await _userService.ListOfRoles()).Select(a => new SelectListItem()
            {
                Text = a.RoleName,
                Value = a.ID.ToString(),
                Selected = false

            }).AsEnumerable();

            ViewBag.Roles = roles;

            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserModel input)
        {
            if(!ModelState.IsValid)
            {
                return View(input);
            }

            _userService.CreateUser(input);

            return Redirect("/account/list");
        }

        [HttpGet]
        [Route("/account/ChangeStatus/{userID}/{enabled}")]
        public async Task<IActionResult> ChangeStatus(int userID,bool enabled)
        {
            try
            {
                await _userService.ChangeStatus(userID, enabled);
                return Redirect("/account/list");

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
