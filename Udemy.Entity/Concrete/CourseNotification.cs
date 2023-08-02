using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Entity.Concrete
{
    public class CourseNotification
    {
        public int CourseNotificationId { get; set; }
        public Course Course { get; set; }
        public Notification Notification { get; set; }
    }
}
