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
    public class CourseNotificationRepository : ICourseNotificationRepository
    {
        private UdemyContext _context;

        public CourseNotificationRepository(UdemyContext context)
        {
            _context = context;
        }

        public void Add(CourseNotification entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(CourseNotification entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public List<CourseNotification> GetAll()
        {
            return _context.CourseNotifications.ToList();
        }

        public CourseNotification GetById(int id)
        {
            return _context.CourseNotifications.Find(id);
        }

        public void Update(CourseNotification entity)
        {
            throw new NotImplementedException();
        }
    }
}
