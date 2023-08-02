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
    public class NotificationRepository : INotificationRepository
    {
        private UdemyContext _context;

        public NotificationRepository(UdemyContext context)
        {
            _context = context;
        }

        public void Add(Notification entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Notification entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public List<Notification> GetAll()
        {
            return _context.Notifications.ToList();
        }

        public Notification GetById(int id)
        {
            return _context.Notifications.Find(id);
        }

        public void Update(Notification entity)
        {
            throw new NotImplementedException();
        }
    }
}
