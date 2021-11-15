using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommissionSystem.WebApplication.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CommissionSystem.WebApplication.Controllers
{
    public class ProductController : Controller
    {
        [Authorize(Policy = "ReadProducts")]
        [HttpGet]
        public IActionResult List()
        {
            return View();
        }
    }
}
