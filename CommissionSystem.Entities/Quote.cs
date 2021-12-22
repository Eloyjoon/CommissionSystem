using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommissionSystem.Entities
{
    public class Quote
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public User Creator { get; set; }
        public User Assignee { get; set; }
        public QuoteStatus QuoteStatus { get; set; }
        public string Description { get; set; }
        public string PersonInCharge { get; set; }
        public DateTime CreationDate { get; set; }

        public List<QuoteItem> QuoteItems { get; set; }
    }
}
