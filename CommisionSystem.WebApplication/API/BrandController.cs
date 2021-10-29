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
        public IEnumerable<ReadBrandModel> Get()
        {
            var list = this.brandService
                .ListOfBrands()
                .Select(a => a.ToReadBrandModel())
                .ToList();

            return list;
        }
    }
}
