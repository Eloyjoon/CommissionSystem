using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommissionSystem.WebApplication.Models.ViewModels;
using CommissionSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommissionSystem.WebApplication.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : BaseApiController
    {
        private readonly IBrandService brandService;

        public BrandController(IBrandService brandService, IMapper mapper) : base(mapper)
        {
            this.brandService = brandService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        [Authorize/*(Policy = "ReadProductsPolicy")*/]
        public async Task<IEnumerable<ReadBrandModel>> Get()
        {
            var userId = Convert.ToInt32(HttpContext.User.Claims.First(a => a.Type == "UserID").Value);

            var list = (await brandService
                .ListOfUserBrands(userId))
                .ToList();

            return mapper.Map<List<ReadBrandModel>>(list);
        }

        [HttpGet("Unique")]
        [Authorize/*(Policy = "ReadProductsPolicy")*/]
        public async Task<IEnumerable<BrandFilter>> Test()
        {
            var userId = Convert.ToInt32(HttpContext.User.Claims.First(a => a.Type == "UserID").Value);

            var list = (await brandService
                .ListOfUserBrands(userId))
                .ToList();

            return mapper.Map<List<ReadBrandModel>>(list).Select(a=>new BrandFilter() { Brand=a.Title}).ToList();
        }
    }
}
