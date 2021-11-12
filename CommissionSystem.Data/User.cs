using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CommissionSystem.Data
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool HasAccessToProductSearchReport { get; set; }
        public bool HasAccessToQuote { get; set; }
        public bool Status { get; set; }
        public int RoleID { get; set; }
        public Role Role { get; set; }
        public User Supervisor { get; set; }
        public ICollection<UserPolicy> UserPolicies { get; set; }

    }
}
