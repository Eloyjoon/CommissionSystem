using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommisionSystem.WebApplication.Data
{
    public class Policy
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}
