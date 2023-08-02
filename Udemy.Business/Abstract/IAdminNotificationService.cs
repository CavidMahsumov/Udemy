using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Entity.Concrete;

namespace Udemy.Business.Abstract
{
    public interface IAdminNotificationService
    {
        AdminNotification GetById(int id);
        List<AdminNotification> GetAll();
        void Add(AdminNotification entity);
        void Delete(AdminNotification entity);
        void Update(AdminNotification entity);
    }
}
