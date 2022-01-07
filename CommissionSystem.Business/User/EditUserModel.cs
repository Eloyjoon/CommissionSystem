using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionSystem.Business.User
{
    public class EditUserModel
    {
        public EditUserModel()
        {

        }

        public EditUserModel(UserDto user, string[] policies, string[] brands)
        {
            UserID = user.ID;
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserName = user.UserName;
            Password = user.Password;
            RoleID = user.Role.ID;
            Policy = policies;
            Brand = brands;
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
