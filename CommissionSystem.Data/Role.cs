using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CommissionSystem.Data
{
    public class Role
    {
        [Key]
        public int ID { get; set; }
        public string RoleName { get; set; }
        public int AccessLevel { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
