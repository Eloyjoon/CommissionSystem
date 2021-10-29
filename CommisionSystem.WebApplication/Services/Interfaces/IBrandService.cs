using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommisionSystem.WebApplication.Services.Interfaces
{
    public interface IBrandService
    {
        IEnumerable<Models.DomainModels.DomainBrand> ListOfBrands();
    }
}
