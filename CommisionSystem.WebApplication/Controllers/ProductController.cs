using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommissionSystem.WebApplication.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CommissionSystem.WebApplication.Controllers
{
    public class ProductController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        public ProductController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize(Policy = "ReadProducts")]
        [HttpGet]
        public IActionResult List()
        {
            this.PageHeaderTitle = "List Of Products";
            return View();
        }

        [HttpGet]
        public DateTime Test()
        {
            var testDate = DateTime.Now;
            return testDate;
        }
    }


}
