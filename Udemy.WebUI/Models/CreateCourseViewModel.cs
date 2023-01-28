using Udemy.Entity.Concrete;

namespace Udemy.WebUI.Models
{
    public class CreateCourseViewModel
    {
        public IFormFile file { get; set; }
        public string ImagePath = "design-logo.png";
        public string CourseTitle { get; set; }
        public string Description { get; set; }
        public string CourseContent { get; set; }
        public string PaidOrFree { get; set; }
        public decimal? Price { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public string TopicName { get; set; }
        public List<ObjectiveAndOutcomes> ObjectiveAndOutcomes { get; set; }
        public List<Video> Videos { get; set; }
    }
}
