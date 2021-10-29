using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommisionSystem.WebApplication.Models.ViewModels
{
    public class ReadProductModel
    {
        public string ProductName { get; set; }
        public string Code { get; set; }
        public int UnitsInStock { get; set; }
        public string Brand { get; set; }
        public string Price { get; set; }
        public string Currency { get; set; }
        public string PriceInRials { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
