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
    public class NotificationManager : INotificationService
    {
        private INotificationRepository _repository;

        public NotificationManager(INotificationRepository repository)
        {
            _repository = repository;
        }

        public void Add(Notification entity)
        {
            _repository.Add(entity);
        }

        public void Delete(Notification entity)
        {
            _repository.Delete(entity);
        }

        public List<Notification> GetAll()
        {
            return _repository.GetAll();
        }

        public Notification GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(Notification entity)
        {
            throw new NotImplementedException();
        }
    }
}
