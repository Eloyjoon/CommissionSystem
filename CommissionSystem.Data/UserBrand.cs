using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionSystem.Data
{
    public class UserBrand
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int BrandID { get; set; }
    }
}
