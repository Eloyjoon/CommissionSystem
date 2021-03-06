using CommissionSystem.Data.Sepidar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommissionSystem.Business.Product
{
    public class ProductDto
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string Code { get; set; }
        public string Store { get; set; }
        public int UnitsInStock { get; set; }
        public int SumStock { get; set; }
        public BrandDto Brand { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public double PriceInRials { get; set; }
        public string JoinedStores { get; set; }

        public ProductDto(Data.Sepidar.Product input)
        {
            this.ID = input.ID;
            this.ProductName = input.Name;
            this.Code = input.Code;
            this.Store = input.Store;
            this.UnitsInStock = Convert.ToInt32(input.Stock);
            this.SumStock = Convert.ToInt32(input.SumStock);
            this.Brand = new BrandDto(input.Brand);
            this.Price = input.Price;
            this.Currency = input.Currency;
            this.PriceInRials = input.PriceInRials;
        }
    }
}
