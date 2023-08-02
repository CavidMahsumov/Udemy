using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Entity.Concrete;

namespace Udemy.Business.Abstract
{
    public interface ICartService
    {
        void AddToCart(Cart cart, Course product);
        void RemoveFromCart(Cart cart, int courseId);
        List<CartItem> GetAll(Cart cart);


    }
}
