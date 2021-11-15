using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommissionSystem.Data
{
    public class Quote
    {
        [Key]
        public int ID { get; set; }
        public int Number { get; set; }
        public int CreatorID { get; set; }
        public User Creator { get; set; }
        public int AssigneeID { get; set; }
        public User Assignee { get; set; }
        public QuoteStatus QuoteStatus { get; set; }
        public string Description { get; set; }
        public string PersonInCharge { get; set; }
        public DateTime CreationDate { get; set; }

        public ICollection<QuoteItem> QuoteItems { get; set; }
    }
}
