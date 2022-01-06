using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommissionSystem.Business.User
{
    public class UserDto
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public RoleDto Role { get; set; }
        public UserDto Supervisor { get; set; }
        public List<PolicyDto> Policies { get; set; }

        public UserDto(Data.User input)
        {
            this.ID = input.ID;
            this.FirstName = input.FirstName;
            this.LastName = input.LastName;
            this.Password = input.Password;
            this.Status = input.Status;
            this.Role = new RoleDto(input.Role);
            if (this.Supervisor != null)
                this.Supervisor = new UserDto(input.Supervisor);
            this.Policies = input?.UserPolicies.Select(a => new PolicyDto(a.Policy)).ToList();
        }
    }
}
