using Udemy.Entity.Concrete;
using Udemy.WebUI.Helper;
using Udemy.WebUI.Identity;

namespace Udemy.WebUI.Models
{
    public class UserViewModel:LayoutViewModel
    {
        public bool? AdminOrUser { get; set; }
        public string TeacherFullName { get; set; }
        public bool haveMyTeacherAccountOrNot { get; set; }
        public User User { get; set; }
        public TeacherAccountViewModel TeacherAccount { get; set; }
        public int SelectedCategoryId { get; set; }
        public int SelectedSubCategoryId { get; set; }
    }
}
