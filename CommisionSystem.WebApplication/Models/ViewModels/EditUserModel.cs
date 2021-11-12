using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionSystem.WebApplication.Models.ViewModels
{
    public class EditUserModel
    {
        public EditUserModel()
        {

        }

        public EditUserModel(Entities.User user,string[] policies,string[] brands)
        {
            this.UserID = user.ID;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.UserName = user.UserName;
            this.Password = user.Password;
            this.RoleID = user.Role.ID;
            this.Policy = policies;
            this.Brand = brands;
        }

        public int UserID { get; set; }
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
    }
}
