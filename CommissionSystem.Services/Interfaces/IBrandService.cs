using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionSystem.Services.Interfaces
{
    public interface IBrandService
    {
        Task<IEnumerable<Entities.Brand>> ListOfBrands();
        Task<IEnumerable<Entities.Brand>> ListOfUserBrands(int userID);
    }
}
