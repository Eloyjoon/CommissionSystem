using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CommissionSystem.WebApplication.Controllers
{
    public class BrandController : BaseController
    {
        [Authorize]
        [HttpGet]
        public IActionResult List()
        {
            this.PageHeaderTitle = "List Of Brands";
            return View();
        }
    }
}
