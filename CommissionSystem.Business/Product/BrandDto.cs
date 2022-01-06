using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommissionSystem.Business.Product
{
    public class BrandDto
    {
        public int ID { get; }
        public string Name { get; }

        public BrandDto(Data.Sepidar.Brand input)
        {
            this.ID = input.ID;
            this.Name = input.Name;
        }
    }
}
