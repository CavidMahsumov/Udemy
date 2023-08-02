using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Business.Abstract;
using Udemy.DataAccess.Abstract;
using Udemy.Entity.Concrete;

namespace Udemy.Business.Concrete
{
    public class AdminNotificationManager : IAdminNotificationService
    {
        private IAdminNotificationRepository _repository;

        public AdminNotificationManager(IAdminNotificationRepository repository)
        {
            _repository = repository;
        }

        public void Add(AdminNotification entity)
        {
            _repository.Add(entity);
        }

        public void Delete(AdminNotification entity)
        {
            _repository.Delete(entity);
        }

        public List<AdminNotification> GetAll()
        {
            return _repository.GetAll();
        }

        public AdminNotification GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(AdminNotification entity)
        {
            throw new NotImplementedException();
        }
    }
}
