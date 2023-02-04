using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Business.Abstract;
using Udemy.DataAccess.Abstract;
using Udemy.Entity.Concrete;

namespace Udemy.Business.Concrete
{
    public class CartManager : ICartService
    {
        public void AddToCart(Cart cart, Course item)
        {
            CartItem cartLine = cart.CartItem.FirstOrDefault(c => c.Course.CourseId == item.CourseId);
            if (cartLine != null)
            {
                cartLine.Quantity++;
            }
            else
                cart.CartItem.Add(new CartItem() { Course = item, Quantity = 1 });
               
        }

        public List<CartItem> GetAll(Cart cart)
        {
            return cart.CartItem;
        }

        public void RemoveFromCart(Cart cart, int courseId)
        {
            cart.CartItem.Remove(cart.CartItem.FirstOrDefault(c => c.Course.CourseId == courseId));

        }

    }
}
