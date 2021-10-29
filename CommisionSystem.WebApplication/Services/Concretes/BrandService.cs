using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommisionSystem.WebApplication.Data.Sepidar;
using CommisionSystem.WebApplication.Models.DomainModels;
using CommisionSystem.WebApplication.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CommisionSystem.WebApplication.Services.Concretes
{
    public class BrandService : IBrandService
    {
        private readonly SepidarContext sepidarContext;

        public BrandService(SepidarContext sepidarContext)
        {
            this.sepidarContext = sepidarContext;
        }
        public IEnumerable<DomainBrand> ListOfBrands()
        {
            var brands = sepidarContext.Brands.Where(a=>a.EntityType== "SG.Inventory.ItemManagement.Common.ItemSaleGroup").ToList();

            return brands.Select(a => a.ToDomainBrand()).ToList();
        }
    }
}
