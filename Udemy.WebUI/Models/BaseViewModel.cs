using Udemy.Business.Abstract;
using Udemy.Entity.Concrete;

namespace Udemy.WebUI.Models
{
    public class BaseViewModel
    {
        public List<Category> Categories { get; set; }
        public List<SubCategory> SubCategories { get; set; }
        public List<Topic> Topics { get; set; }
        public List<Course> Course { get; set; }
    }
}
