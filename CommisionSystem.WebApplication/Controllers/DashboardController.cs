using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CommissionSystem.WebApplication.Controllers
{
    public class DashboardController : Controller
    {

        [Authorize(Policy = "Dashboard")]
        public IActionResult Expert()
        {
            return View();
        }

        public IActionResult DraftQuotes()
        {
            return View();
        }
    }
}
