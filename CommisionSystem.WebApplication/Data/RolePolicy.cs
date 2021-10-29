using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CommisionSystem.WebApplication.Data
{
    public class RolePolicy
    {
        [Key]
        public int ID { get; set; }
        public int RoleID { get; set; }
        [JsonIgnore]
        public Role Role { get; set; }
        public string Policy { get; set; }
    }
}
