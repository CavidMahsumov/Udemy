using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Entity.Concrete
{
    public class AdminNotification
    {
        public int AdminNotificationId { get; set; }
        public ICollection<CourseNotification> CourseNotifications =new List<CourseNotification>();
        public ICollection<Course> Courses =new List<Course>();

    }
}
