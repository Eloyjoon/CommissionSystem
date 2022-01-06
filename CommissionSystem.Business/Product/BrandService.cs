using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommissionSystem.Data;
using CommissionSystem.Data.Sepidar;
using Microsoft.EntityFrameworkCore;

namespace CommissionSystem.Business.Product
{
    public class BrandService : IBrandService
    {
        private readonly SepidarContext sepidarContext;
        private readonly CommisionContext commisionContext;

        public BrandService(SepidarContext sepidarContext, CommisionContext commisionContext)
        {
            this.sepidarContext = sepidarContext;
            this.commisionContext = commisionContext;
        }
        public async Task<IEnumerable<BrandDto>> ListOfBrands()
        {
            var brands = await sepidarContext.Brands
                .OnlyBrands()
                .Select(a => new BrandDto(a))
                .ToListAsync();

            return brands;
        }

        public async Task<IEnumerable<BrandDto>> ListOfUserBrands(int userID)
        {
            var user = commisionContext.Users
                .Include(a => a.Role)
                .First(a => a.ID == userID);

            if (user.Role.AccessLevel >= 30)
            {
                var brands = await ListOfBrands();
                return brands;
            }
            else
            {
                var userBrands = commisionContext.UserBrands
                    .Where(a => a.UserID == userID)
                    .Select(x => x.BrandID)
                    .ToList();

                var brands = (await ListOfBrands())
                    .Where(x => userBrands.Contains(x.ID))
                    .ToList();

                return brands;
            }
        }
    }
}
