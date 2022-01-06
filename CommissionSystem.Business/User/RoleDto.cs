using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommissionSystem.Business.User
{
    public class RoleDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int AccessLevel { get; set; }

        public RoleDto(Data.Role input)
        {
            this.ID = input.ID;
            this.Name = input.RoleName;
            this.AccessLevel = input.AccessLevel;
        }
    }
}
