using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.DataAccess.Abstract;
using Udemy.DataAccess.Concrete.EntityFramework;
using Udemy.Entity.Concrete;

namespace Udemy.DataAccess.Concrete
{
    internal class CartItemRepository : ICartItemRepository
    {
        private UdemyContext _context;
        public void Add(CartItem entity)
        {
            _context.CartItems.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(CartItem entity)
        {
            _context.CartItems.Remove(entity);
            _context.SaveChanges();
        }


        public List<CartItem> GetAll()
        {
            return _context.CartItems.ToList();
        }

        public CartItem GetById(int id)
        {
            return _context.CartItems.Find(id);    
        }

        public void Update(CartItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
