using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionSystem.WebApplication.Controllers
{
    public class BaseController : Controller
    {
        private string pageHeaderTitle;

        public string PageHeaderTitle
        {
            get => pageHeaderTitle; set
            {
                ViewBag.PageHeaderTitle = value;
                pageHeaderTitle = value;
            }
        }
    }
}
