using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommisionSystem.WebApplication.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Models.DomainModels.DomainProduct> ListOfProducts();
    }
}
