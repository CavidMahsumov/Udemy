using Udemy.Entity.Concrete;

namespace Udemy.WebUI.Models
{
    public class TeacherAccountViewModel:LayoutViewModel
    {
        public string MyId { get; set; }
        public Teacher MyTeacherAccount { get; set; }
        public CreateCourseViewModel CourseViewModel { get; set; }

    }
}
