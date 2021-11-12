using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionSystem.Entities
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int UnitsInStock { get; set; }
        public Brand Brand { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public double PriceInRials { get; set; }
        public DateTime LastUpdate { get; set; }

    }
}
