using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionSystem.WebApplication.Models.ViewModels
{
    public class ReadProductModel
    {
        private string currency;

        public int ID { get; set; }
        public string ProductName { get; set; }
        public string Code { get; set; }
        public int UnitsInStock { get; set; }
        public int SumStock { get; set; }
        public string Store { get; set; }
        public string JoinedStores { get; set; }
        public string Brand { get; set; }
        public string Price { get; set; }
        public string Currency
        {
            get => currency; 
            set
            {               
                currency = value;
            }
        }
        public string PriceInRials { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
