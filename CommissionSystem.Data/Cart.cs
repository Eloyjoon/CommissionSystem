using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommissionSystem.Data
{
    public class Cart
    {
        [Key]
        public int ID { get; set; }
        public ICollection<CartItem> CartItems { get; set; }

    }

    public class CartItem
    {
        public int ID { get; set; }
        public int CartID { get; set; }
        public Cart Cart { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int MyProperty { get; set; }
    }
}
