using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Entity.Concrete
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public Course Course { get; set; }
        public int Quantity { get; set; }

    }
}
