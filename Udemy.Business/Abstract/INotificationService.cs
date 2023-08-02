using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Entity.Concrete;

namespace Udemy.Business.Abstract
{
    public interface INotificationService
    {
        Notification GetById(int id);
        List<Notification> GetAll();
        void Add(Notification entity);
        void Delete(Notification entity);
        void Update(Notification entity);
    }
}
