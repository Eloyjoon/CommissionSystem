using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommissionSystem.Data
{
    public static class Extensions
    {
        public static IQueryable<Sepidar.Brand> OnlyBrands(this DbSet<Sepidar.Brand> input)
        {
            return input.Where(a => a.EntityType == "SG.Inventory.ItemManagement.Common.ItemSaleGroup");
        }

    }
}
