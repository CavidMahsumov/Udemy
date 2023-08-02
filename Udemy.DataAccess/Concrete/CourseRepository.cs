using Microsoft.EntityFrameworkCore;
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
    public class CourseRepository : ICourseRepository
    {
        private UdemyContext _context;

        public CourseRepository(UdemyContext context)
        {
            _context = context;
        }

        public void Add(Course entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Course entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public List<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return _context.Courses.Find(id);
        }

        public void Update(Course entity)
        {
            throw new NotImplementedException();
        }
    }
}
