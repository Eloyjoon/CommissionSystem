using System;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CommissionSystem.WebApplication.Models.ViewModels;
using CommissionSystem.WebApplication.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using CommissionSystem.Business.Product;
using CommissionSystem.Business.User;

namespace CommissionSystem.WebApplication.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IBrandService _brandService;

        public AccountController(IUserService userService, IBrandService brandService, IMapper mapper) : base(mapper)
        {
            _userService = userService;
            _brandService = brandService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var user = await _userService.Exist(loginModel.UserName);

            if (user == null)
            {
                ModelState.AddModelError("", "User not found");
                return View(loginModel);
            }

            if (user.Role.Name.ToLower().Contains("super"))//Super Admin
            {
                user = await _userService.GetUser(loginModel.UserName, loginModel.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Username and password not match");
                    return View(loginModel);
                }
                if (!user.Status)
                {
                    ModelState.AddModelError("", "Account is disabled. Call the admin.");
                    return View(loginModel);
                }
            }
            else
            {
                PrincipalContext pc = new PrincipalContext(ContextType.Domain, "hurmengroup.local");
                bool valid = pc.ValidateCredentials(loginModel.UserName, loginModel.Password);
                if (!valid)
                {
                    ModelState.AddModelError("", "Username and password not match");
                    return View(loginModel);
                }
            }

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim("UserID", user.ID.ToString()));
            identity.AddClaim(new Claim("FirstName", user.FirstName));
            identity.AddClaim(new Claim("LastName", user.LastName));
            identity.AddClaim(new Claim("RoleName", user.Role.Name));
            identity.AddClaim(new Claim("AccessLevel", user.Role.AccessLevel.ToString()));
            foreach (var item in user.Policies)
            {
                identity.AddClaim(new Claim(item.Name, "true"));
            }

            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            if (string.IsNullOrEmpty(loginModel.ReturnUrl))
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
                Text = a.Name,
                Value = a.ID.ToString(),
                Selected = false

            }).AsEnumerable();

            var policies = (await _userService.ListOfPolicies())
                .OrderBy(a => a.Name)
                .ToList();

            var brands = (await _brandService.ListOfBrands())
                .OrderBy(x => x.Name)
                .ToList();

            ViewBag.Roles = roles;
            ViewBag.Policies = mapper.Map<List<ReadPolicyModel>>(policies);
            ViewBag.Brands = mapper.Map<List<ReadBrandModel>>(brands); ;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserModel input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }

            var user = mapper.Map<UserDto>(input);
            var selectedBrandsList = input.Brand.Select(a => Convert.ToInt32(a)).ToList();
            var selectedPoliciesList = input.Policy.Select(a => Convert.ToInt32(a)).ToList();

            await _userService.CreateUser(user, selectedPoliciesList, selectedBrandsList);

            return Redirect("/account/list");
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(int id)
        {
            var roles = (await _userService.ListOfRoles()).Select(a => new SelectListItem()
            {
                Text = a.Name,
                Value = a.ID.ToString(),
                Selected = false

            }).AsEnumerable();

            var policies = (await _userService.ListOfPolicies())
                .OrderBy(a => a.DisplayName)
                .ToList();

            var brands = (await _brandService.ListOfBrands())
                .OrderBy(x => x.Name)
                .ToList();

            ViewBag.Roles = roles;
            ViewBag.Policies = mapper.Map<List<ReadPolicyModel>>(policies);
            ViewBag.Brands = mapper.Map<List<ReadBrandModel>>(brands); ;

            var user = await _userService.GetUser(id);

            var userBrands = (await _userService.GetUserBrands(id))
                .Select(a=>a.ID.ToString())
                .ToArray();

            var userPolicies = (await _userService.GetUserPolicy(id))
                .Select(a => a.ID.ToString())
                .ToArray();

            var result = new EditUserModel(user, userPolicies, userBrands);

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserModel editUserModel)
        {
            var roles = (await _userService.ListOfRoles()).Select(a => new SelectListItem()
            {
                Text = a.Name,
                Value = a.ID.ToString(),
                Selected = false

            }).AsEnumerable();

            var policies = (await _userService.ListOfPolicies())
                .OrderBy(a => a.Name)
                .ToList();

            var brands = (await _brandService.ListOfBrands())
                .OrderBy(x => x.Name)
                .ToList();

            ViewBag.Roles = roles;
            ViewBag.Policies = mapper.Map<List<ReadPolicyModel>>(policies);
            ViewBag.Brands = mapper.Map<List<ReadBrandModel>>(brands);

            if (!ModelState.IsValid)
            {
                return View(editUserModel);
            }

            if (editUserModel.Policy == null)
                editUserModel.Policy = Array.Empty<string>();

            if (editUserModel.Brand == null)
                editUserModel.Brand = Array.Empty<string>();



            var user = mapper.Map<Entities.User>(editUserModel);
            var selectedBrandsList = editUserModel.Brand.Select(a => Convert.ToInt32(a)).ToList();
            var selectedPoliciesList = editUserModel.Policy.Select(a => Convert.ToInt32(a)).ToList();

            await _userService.EditUser(user, selectedBrandsList, selectedPoliciesList);

            return Redirect("/account/list");
        }

        [HttpPost]
        public async Task<IActionResult> SyncUsers()
        {
            await _userService.SyncUsers();

            return Redirect("/account/list");
        }

        [HttpGet]
        [Route("/account/ChangeStatus/{userID}/{enabled}")]
        public async Task<IActionResult> ChangeStatus(int userID, bool enabled)
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
