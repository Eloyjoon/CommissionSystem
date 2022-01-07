using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionSystem.Business.Product
{
    public class ReadProductModel : ProductDto
    {
        public ReadProductModel(Data.Sepidar.Product input) : base(input)
        {
        }

        public string BrandName => base.Brand.Name;
        public string PriceString => Price.ToString("#,##0.#");
        public string PriceInRialsString => Convert.ToInt32(PriceInRials).ToString("#,##0.#");
    }
}
