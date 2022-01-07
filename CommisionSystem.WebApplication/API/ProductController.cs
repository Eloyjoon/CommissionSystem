using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CommissionSystem.Business.Product;

namespace CommissionSystem.WebApplication.API
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
        [Authorize(Policy = "ReadProducts")]
        public async Task<IEnumerable<ReadProductModel>> Get(bool grouped)
        {
            var userId = Convert.ToInt32(HttpContext.User.Claims.First(a => a.Type == "UserID").Value);

            var list =await productService
                .ListOfUserProducts(userId,grouped);

            return list;
        }
    }
}
