using System.ComponentModel.DataAnnotations;

namespace CommissionSystem.Data
{
    public class QuoteItem 
    {
        [Key]
        public int ID { get; set; }
        public int QuoteID { get; set; }
        public Quote Quote { get; set; }
        public int ProductID { get; set; }
        public int Count { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitPriceInRials { get; set; }
        public decimal TotalPrice { get; set; }
        public int TotalPriceInRials { get; set; }
        public int Commission { get; set; }
    }
}
