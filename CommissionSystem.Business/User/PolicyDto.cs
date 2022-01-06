using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommissionSystem.Business.User
{
    public class PolicyDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public PolicyDto(Data.Policy input)
        {
            this.ID = input.ID;
            this.Name = input.Name;
            this.DisplayName = input.DisplayName;
        }
    }
}
