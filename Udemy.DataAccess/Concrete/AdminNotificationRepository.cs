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
    public class AdminNotificationRepository : IAdminNotificationRepository
    {

        private UdemyContext _context;

        public AdminNotificationRepository(UdemyContext context)
        {
            _context = context;
        }

        public void Add(AdminNotification entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(AdminNotification entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public List<AdminNotification> GetAll()
        {
            return _context.AdminNotifications.ToList();
        }

        public AdminNotification GetById(int id)
        {
            return _context.AdminNotifications.Find(id);
        }

        public void Update(AdminNotification entity)
        {
            throw new NotImplementedException();
        }
    }
}
