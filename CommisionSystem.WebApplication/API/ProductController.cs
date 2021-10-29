using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommisionSystem.WebApplication.Models.ViewModels;
using CommisionSystem.WebApplication.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommisionSystem.WebApplication.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        [Authorize(Policy = "ReadProductsPolicy")]
        public IEnumerable<ReadProductModel> Get()
        {
            var list = this.productService
                .ListOfProducts()
                .Select(a => a.ToReadProductModel())
                .Take(100)
                .ToList();

            return list;
        }
    }
}
