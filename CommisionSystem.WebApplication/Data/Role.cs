using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CommisionSystem.WebApplication.Data
{
    public class Role
    {
        [Key]
        public int ID { get; set; }
        public string RoleName { get; set; }
        public int AccessLevel { get; set; } 
        public ICollection<User> Users { get; set; }
        public ICollection<RolePolicy> RolePolicies { get; set; }
    }
}
