using Microsoft.AspNetCore.Identity;

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
    }
}
