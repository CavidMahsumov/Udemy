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
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private UdemyContext _context;

        public SubCategoryRepository(UdemyContext context)
        {
            _context = context;
        }

        public void Add(SubCategory entity)
        {
            _context.SubCategories.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(SubCategory entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public List<SubCategory> GetAll()
        {
            return _context.SubCategories.ToList();
        }

        public SubCategory GetById(int id)
        {
            return _context.SubCategories.Find(id);
        }

        public void Update(SubCategory entity)
        {
            throw new NotImplementedException();
        }
    }
}
