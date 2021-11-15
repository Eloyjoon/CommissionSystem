using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionSystem.WebApplication.API
{
    public class BaseApiController : ControllerBase
    {
        public readonly IMapper mapper;

        public BaseApiController(IMapper mapper)
        {
            this.mapper = mapper;
        }
    }
}
