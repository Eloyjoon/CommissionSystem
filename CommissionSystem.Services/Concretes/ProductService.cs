using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CommissionSystem.Data;
using CommissionSystem.Data.Sepidar;
using CommissionSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CommissionSystem.Services.Concretes
{
    public class ProductService :BaseService, IProductService
    {
        private readonly SepidarContext sepidarContext;
        private readonly CommisionContext commisionContext;

        public ProductService(SepidarContext sepidarContext, CommisionContext commisionContext, IMapper mapper) : base(mapper)
        {
            this.sepidarContext = sepidarContext;
            this.commisionContext = commisionContext;
        }
        private IEnumerable<Entities.Product> ListOfProducts()
        {
            var products = sepidarContext.Products.FromSqlRaw(@"Select i.ItemID as ID,
	   i.code,
       i.Title as Name,
	   I.SaleGroupRef as BrandID,
       g.Title as [برند],
       iss.Quantity as Stock,
       s.Title as [انبار],
	   sum(iss.Quantity) over(partition by i.ItemID) as [موجودی کلی],
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
where iss.fiscalyearref = 6").Include(a => a.Brand).ToList();
            return mapper.Map<List<Entities.Product>>(products);

        }
        public IEnumerable<Entities.Product> ListOfUserProducts(int userID)
        {
            var user = commisionContext.Users
                .Include(a => a.Role)
                .First(a => a.ID == userID);

            if (user.Role.AccessLevel >= 30)
            {
                var products = ListOfProducts()
                    .ToList();

                return products;
            }
            else
            {
                var userBrands = commisionContext.UserBrands
                    .Where(a => a.UserID == userID)
                    .Select(x => x.BrandID)
                    .ToList();

                var products = ListOfProducts()
                    .Where(a => userBrands.Contains(a.Brand.ID))
                    .ToList();

                return products;
            }
        }

    }
}
