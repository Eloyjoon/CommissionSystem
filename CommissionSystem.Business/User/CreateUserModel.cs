using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionSystem.Business.User
{
    public class CreateUserModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int RoleID { get; set; }
        public string[] Policy { get; set; }
        public string[] Brand { get; set; }

        public Data.User ToUser()
        {
            Data.User user = new();
            user.FirstName = this.FirstName;
            user.LastName = this.LastName;
            user.UserName = this.UserName;
            user.Password = this.Password;
            user.RoleID = this.RoleID;

        }
    }
}
