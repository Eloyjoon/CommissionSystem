using System.ComponentModel.DataAnnotations;

namespace CommissionSystem.Data
{
    public class QuoteStatus
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
    }
}