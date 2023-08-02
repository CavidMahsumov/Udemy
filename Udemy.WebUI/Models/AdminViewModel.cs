using Microsoft.AspNetCore.Identity;
using Udemy.Entity.Concrete;
using Udemy.WebUI.Identity;

namespace Udemy.WebUI.Models
{
    public class AdminViewModel:BaseViewModel
    {
        public List<IdentityRole> RoleList { get; set; }
        public RoleModel roleModel { get; set; }
        public AddCategoryModel addCategoryModel { get; set; }
        public AddSubCategoryModel addSubCategoryModel { get; set; }
        public AddTopicModel addTopicModel { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public string TopicName { get; set; }
        public int CategoryIdForAdd { get; set; }
        public int SubCategoryIdForAdd { get; set; }
        public bool AdminOrUser { get; set; }

        public List<AdminNotification> AdminNotifications { get; set; }

        public int CourseDetailsId { get; set; }
        public User UserForShowDetails { get; set; }

        public int AcceptedCourseId { get; set; }
        public int AcceptedANId { get; set; }
    }
}
