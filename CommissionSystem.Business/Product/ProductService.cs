using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommissionSystem.Data;
using CommissionSystem.Data.Sepidar;
using Microsoft.EntityFrameworkCore;

namespace CommissionSystem.Business.Product
{
    public class ProductService : IProductService
    {
        private readonly SepidarContext sepidarContext;
        private readonly CommisionContext commisionContext;

        public ProductService(SepidarContext sepidarContext, CommisionContext commisionContext)
        {
            this.sepidarContext = sepidarContext;
            this.commisionContext = commisionContext;
        }

        private async Task<IEnumerable<ReadProductModel>> ListOfProducts()
        {
            var products = await sepidarContext.Products.FromSqlRaw(@"Select i.ItemID as ID,
	   i.code,
       i.Title as Name,
	   I.SaleGroupRef as BrandID,
       g.Title as [برند],
       iss.Quantity as Stock,
       s.Title as Store,
	   sum(iss.Quantity) over(partition by i.ItemID) as SumStock,
       fee.Fee as price,
       fee.currency,
       exchangeRate.EffectiveDate as lastupdate,
       cast(exchangeRate.ExchangeRate * fee.Fee as float) as priceinrials
from inv.item i
    left join gnr.grouping g
        on I.SaleGroupRef = g.GroupingID
    join inv.ItemStockSummary iss
        on iss.ItemRef = i.ItemID
    join inv.stock s
        on iss.StockRef = s.StockID
    cross apply
(
    select top 1
        fee,
        c.Title as currency,
        c.CurrencyID
    from sls.pricenoteitem pni
        join sls.PriceNote pn
            on pni.PriceNoteRef = pn.PriceNoteID
        join gnr.currency c
            on pni.CurrencyRef = c.CurrencyID
    where itemref = i.ItemID
    order by pn.Date desc
) as fee
    cross apply
(
    SELECT top 1
        cer.EffectiveDate,
        cer.ExchangeRate
    FROM GNR.CurrencyExchangeRate cer
    Where cer.FiscalYearRef = 6
          and cer.CurrencyRef = fee.CurrencyID
    order by cer.EffectiveDate desc
) as exchangeRate
where iss.fiscalyearref = 6")
                .Include(a => a.Brand)
                .Select(a => new ReadProductModel(a))
                .ToListAsync();

            return products;
        }
        private async Task<IEnumerable<ReadProductModel>> ListOfProductsGrouped()
        {
            var products = await sepidarContext.Products.FromSqlRaw(@"Select i.ItemID as ID,
	   i.code,
       i.Title as Name,
	   I.SaleGroupRef as BrandID,
       g.Title as [برند],
       iss.Quantity as Stock,
       s.Title as Store,
	   sum(iss.Quantity) over(partition by i.ItemID) as SumStock,
       fee.Fee as price,
       fee.currency,
       exchangeRate.EffectiveDate as lastupdate,
       cast(exchangeRate.ExchangeRate * fee.Fee as float) as priceinrials
from inv.item i
    left join gnr.grouping g
        on I.SaleGroupRef = g.GroupingID
    join inv.ItemStockSummary iss
        on iss.ItemRef = i.ItemID
    join inv.stock s
        on iss.StockRef = s.StockID
    cross apply
(
    select top 1
        fee,
        c.Title as currency,
        c.CurrencyID
    from sls.pricenoteitem pni
        join sls.PriceNote pn
            on pni.PriceNoteRef = pn.PriceNoteID
        join gnr.currency c
            on pni.CurrencyRef = c.CurrencyID
    where itemref = i.ItemID
    order by pn.Date desc
) as fee
    cross apply
(
    SELECT top 1
        cer.EffectiveDate,
        cer.ExchangeRate
    FROM GNR.CurrencyExchangeRate cer
    Where cer.FiscalYearRef = 6
          and cer.CurrencyRef = fee.CurrencyID
    order by cer.EffectiveDate desc
) as exchangeRate
where iss.fiscalyearref = 6")
                .Include(a => a.Brand)
                .ToListAsync();

            List<ReadProductModel> groupedList = new();

            foreach (var item in products.Select(a=>new ReadProductModel(a)))
            {
                var result = groupedList.FirstOrDefault(a => a.ID == item.ID);
                if (result != null)
                {
                    result.JoinedStores += "</br>" + item.Store.Replace("انبار ", string.Empty) + "=" + item.UnitsInStock;
                }
                else
                {
                    item.JoinedStores = item.Store.Replace("انبار ", string.Empty) + "=" + item.UnitsInStock;
                    groupedList.Add(item);
                }
            }

            return groupedList;

        }
        public async Task<IEnumerable<ReadProductModel>> ListOfUserProducts(int userID, bool grouped)
        {
            var user = await commisionContext.Users
                .Include(a => a.Role)
                .FirstAsync(a => a.ID == userID);

            if (user.Role.AccessLevel >= 30)
            {
                var products = grouped ? (await ListOfProductsGrouped()).ToList() : (await ListOfProducts()).ToList();
                return products;
            }
            else
            {
                var userBrands =await commisionContext.UserBrands
                    .Where(a => a.UserID == userID)
                    .Select(x => x.BrandID)
                    .ToListAsync();

                var products = grouped ? (await ListOfProductsGrouped()).ToList() : (await ListOfProducts()).ToList();

                products =products
                    .Where(a => userBrands.Contains(a.Brand.ID))
                    .ToList();

                return products;
            }
        }
    }
}
