using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommissionSystem.WebApplication.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CommissionSystem.Business.Product;

namespace CommissionSystem.WebApplication.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService brandService;

        public BrandController(IBrandService brandService)
        {
            this.brandService = brandService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        [Authorize/*(Policy = "ReadProductsPolicy")*/]
        public async Task<IEnumerable<BrandDto>> Get()
        {
            var userId = Convert.ToInt32(HttpContext.User.Claims.First(a => a.Type == "UserID").Value);

            var list = (await brandService
                .ListOfUserBrands(userId))
                .ToList();

            return list;
        }

        [HttpGet("Unique")]
        [Authorize/*(Policy = "ReadProductsPolicy")*/]
        public async Task<IEnumerable<BrandFilter>> Test()
        {
            var userId = Convert.ToInt32(HttpContext.User.Claims.First(a => a.Type == "UserID").Value);

            var list = (await brandService
                .ListOfUserBrands(userId))
                .ToList();

            return list.Select(a=>new BrandFilter() { Brand=a.Name}).ToList();
        }
    }
}
