using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionSystem.WebApplication.Controllers
{
    public class BaseController : Controller
    {
        public readonly IMapper mapper;
        private string pageHeaderTitle;

        public string PageHeaderTitle
        {
            get => pageHeaderTitle; set
            {
                ViewBag.PageHeaderTitle = value;
                pageHeaderTitle = value;
            }
        }

        public BaseController(IMapper mapper)
        {
            this.mapper = mapper;
        }
    }
}
