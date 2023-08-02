using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Entity.Concrete
{
    public class Cart
    {

        public int CartId { get; set; }
        public List<CartItem> CartItem { get; set; }
        public int UserId { get; set; }
    }
}
