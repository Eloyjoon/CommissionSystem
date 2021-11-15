using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommissionSystem.Data;
using CommissionSystem.Data.Sepidar;
using CommissionSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CommissionSystem.Services.Concretes
{
    public class BrandService : BaseService, IBrandService
    {
        private readonly SepidarContext sepidarContext;
        private readonly CommisionContext commisionContext;

        public BrandService(SepidarContext sepidarContext, CommisionContext commisionContext,IMapper mapper):base(mapper)
        {
            this.sepidarContext = sepidarContext;
            this.commisionContext = commisionContext;
        }
        public async Task<IEnumerable<Entities.Brand>> ListOfBrands()
        {
            var brands = await sepidarContext.Brands.OnlyBrands().ToListAsync();

            return mapper.Map<List<Entities.Brand>>(brands);
        }

        public async Task<IEnumerable<Entities.Brand>> ListOfUserBrands(int userID)
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
