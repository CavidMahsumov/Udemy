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
    public class CartRepository : ICartRepository
    {
        private UdemyContext _context;

        public CartRepository(UdemyContext context)
        {
            _context = context;
        }

        public void Add(Cart entity)
        {
            _context.Carts.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Cart entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public List<Cart> GetAll()
        {
            return _context.Carts.ToList();

        }

        public Cart GetById(int id)
        {
            return _context.Carts.Find(id);
        }

        public void Update(Cart entity)
        {
            throw new NotImplementedException();
        }
    }
}
