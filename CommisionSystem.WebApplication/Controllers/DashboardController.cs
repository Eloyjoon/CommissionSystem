using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CommisionSystem.WebApplication.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Expert()
        {
            return View();
        }
    }
}
