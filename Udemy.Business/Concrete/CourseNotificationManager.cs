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
    public class CourseNotificationManager : ICourseNotificationService
    {
        private ICourseNotificationRepository _repository;

        public CourseNotificationManager(ICourseNotificationRepository repository)
        {
            _repository = repository;
        }

        public void Add(CourseNotification entity)
        {
            _repository.Add(entity);
        }

        public void Delete(CourseNotification entity)
        {
            _repository.Delete(entity);
        }

        public List<CourseNotification> GetAll()
        {
            return _repository.GetAll();
        }

        public CourseNotification GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(CourseNotification entity)
        {
            throw new NotImplementedException();
        }
    }
}
