using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Entity.Concrete
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string MyUserId { get; set; }
        public string FullName { get; set; }
        public string FieldOfWork { get; set; }
        public string AboutMe { get; set; }
        public ICollection<Course> MyCourses { get; set; }
        public int MyStudentCount { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}
