using CommissionSystem.Data.Sepidar;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommissionSystem.Business.Product
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandDto>> ListOfBrands();
        Task<IEnumerable<BrandDto>> ListOfUserBrands(int userID);
    }
}
