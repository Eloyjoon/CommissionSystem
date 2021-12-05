using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommissionSystem.WebApplication.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CommissionSystem.WebApplication.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(IMapper mapper) : base(mapper)
        {
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
