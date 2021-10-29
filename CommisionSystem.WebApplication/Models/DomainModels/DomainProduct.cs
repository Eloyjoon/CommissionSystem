using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommisionSystem.WebApplication.Models.DomainModels
{
    public class DomainProduct
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int UnitsInStock { get; set; }
        public DomainBrand Brand { get; set; }
        public string Price { get; set; }
        public string Currency { get; set; }
        public string PriceInRials { get; set; }
        public DateTime LastUpdate { get; set; }

    }
}
