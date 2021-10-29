using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommisionSystem.WebApplication.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CommisionSystem.WebApplication.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService brandService;

        public BrandController(IBrandService brandService)
        {
            this.brandService = brandService;
        }
        [Authorize]
        [HttpGet]
        public IActionResult List()
        {
            //var list = this.brandService
            //    .ListOfBrands()
            //    .Select(a => a.ToReadBrandModel())
            //    .ToList();

            return View();
        }
    }
}
