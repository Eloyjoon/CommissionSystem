using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommisionSystem.WebApplication.Models.ViewModels
{
    public class ReadUserModel
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public bool Status { get; set; }
    }
}
