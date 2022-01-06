using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommissionSystem.Business.Product
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> ListOfUserProducts(int userID, bool grouped);
    }
}
