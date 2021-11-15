using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommissionSystem.Services.Concretes
{
    public class BaseService
    {
        protected readonly IMapper mapper;

        public BaseService(IMapper mapper)
        {
            this.mapper = mapper;
        }
    }
}
