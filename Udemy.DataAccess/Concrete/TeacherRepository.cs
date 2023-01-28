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
    public class TeacherRepository : ITeacherRepository
    {
        private UdemyContext _context;

        public TeacherRepository(UdemyContext context)
        {
            _context = context;
        }

        public void Add(Teacher entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Teacher entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public List<Teacher> GetAll()
        {
            return _context.Teachers.ToList();
        }

        public Teacher GetById(int id)
        {
            return _context.Teachers.Find(id);
        }

        public void Update(Teacher entity)
        {
            throw new NotImplementedException();
        }
    }
}
