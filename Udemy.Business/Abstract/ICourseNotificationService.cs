using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Entity.Concrete;

namespace Udemy.Business.Abstract
{
    public interface ICourseNotificationService
    {
        CourseNotification GetById(int id);
        List<CourseNotification> GetAll();
        void Add(CourseNotification entity);
        void Delete(CourseNotification entity);
        void Update(CourseNotification entity);
    }
}
