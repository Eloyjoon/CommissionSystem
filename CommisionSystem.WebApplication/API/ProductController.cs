using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommissionSystem.WebApplication.Models.ViewModels;
using CommissionSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace CommissionSystem.WebApplication.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseApiController
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService,IMapper mapper):base(mapper)
        {
            this.productService = productService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        [Authorize(Policy = "ReadProducts")]
        public IEnumerable<ReadProductModel> Get(bool grouped)
        {
            var userId = Convert.ToInt32(HttpContext.User.Claims.First(a => a.Type == "UserID").Value);

            var list = productService
                .ListOfUserProducts(userId,grouped);

            var result = mapper.Map<IEnumerable<ReadProductModel>>(list);

            return result;
        }
    }
}
