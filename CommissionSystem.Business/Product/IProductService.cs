using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommissionSystem.Business.Product
{
    public interface IProductService
    {
        Task<IEnumerable<ReadProductModel>> ListOfUserProducts(int userID, bool grouped);
    }
}
