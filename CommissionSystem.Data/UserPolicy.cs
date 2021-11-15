using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionSystem.Data
{
    public class UserPolicy
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int PolicyID { get; set; }
        public Policy Policy { get; set; }
    }
}
