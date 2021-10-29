using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommisionSystem.WebApplication.Data;
using CommisionSystem.WebApplication.Data.Sepidar;
using CommisionSystem.WebApplication.Models.DomainModels;
using CommisionSystem.WebApplication.Models.ViewModels;

namespace CommisionSystem.WebApplication
{
    public static class Extentsions
    {
        #region Fiscal Year

        public static DomainFiscalYear ToDomainFiscalYear(this FiscalYear fiscalYear)
        {
            DomainFiscalYear domainFiscalYear = new DomainFiscalYear
            {
                ID = fiscalYear.ID,
                Title = fiscalYear.Title
            };

            return domainFiscalYear;
        }

        public static ReadFiscalYearModel ToReadFiscalYearModel(this DomainFiscalYear domainFiscalYear)
        {
            ReadFiscalYearModel readFiscalYearModel = new ReadFiscalYearModel
            {
                ID = domainFiscalYear.ID,
                Title = domainFiscalYear.Title
            };

            return readFiscalYearModel;
        }

        #endregion

        #region Product

        public static DomainProduct ToDomainProduct(this Product product)
        {
            DomainProduct domainProduct = new DomainProduct
            {
                ID = product.ID,
                Code = product.Code,
                Name = product.Name,
                Brand=product.Brand.ToDomainBrand(),
                Currency=product.Currency,
                LastUpdate=product.LastUpdate,
                Price=product.Price.ToString(),
                PriceInRials=product.PriceInRials.ToString(),
                UnitsInStock=Convert.ToInt32(product.Stock)                
                
            };

            return domainProduct;
        }

        public static ReadProductModel ToReadProductModel(this DomainProduct domainProduct)
        {
            ReadProductModel readProductModel = new ReadProductModel
            {
                ProductName = domainProduct.Name,
                Code = domainProduct.Code,
                Brand=domainProduct.Brand.Name,
                Currency=domainProduct.Currency.ToString(),
                LastUpdate=domainProduct.LastUpdate,
                Price=domainProduct.Price.ToString(),
                PriceInRials=domainProduct.PriceInRials.ToString(),
                UnitsInStock=domainProduct.UnitsInStock
            };

            return readProductModel;
        }

        #endregion

        #region MyRegion

        public static ReadUserModel ToReadUserModel(this User input)
        {
            ReadUserModel readUserModel = new ReadUserModel()
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                RoleName = input.Role.RoleName,
                UserID = input.ID,
                UserName = input.UserName,
                Status=input.Status
            };

            return readUserModel;
        }
        #endregion


        public static DomainBrand ToDomainBrand(this Brand brand)
        {
            DomainBrand domainBrand = new DomainBrand
            {
                ID = brand.ID,
                Name = brand.Name
            };

            return domainBrand;
        }

        public static ReadBrandModel ToReadBrandModel(this DomainBrand domainBrand)
        {
            ReadBrandModel readBrandModel = new ReadBrandModel
            {
                ID=domainBrand.ID,
                Name=domainBrand.Name
            };

            return readBrandModel;
        }
    }
}
