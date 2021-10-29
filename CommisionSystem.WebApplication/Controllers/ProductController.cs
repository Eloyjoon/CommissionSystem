using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommisionSystem.WebApplication.Models.ViewModels;
using CommisionSystem.WebApplication.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CommisionSystem.WebApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [Authorize]
        [HttpGet]
        public IActionResult List()
        {
            var list= this.productService
                .ListOfProducts()
                .Select(a=>a.ToReadProductModel())
                .ToList();

            return View(list);
        }
    }
}
