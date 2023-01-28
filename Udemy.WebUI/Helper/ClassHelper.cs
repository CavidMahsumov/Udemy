using Udemy.Business.Abstract;
using Udemy.Entity.Concrete;

namespace Udemy.WebUI.Helper
{
    public static class ClassHelper
    {
        public static int CategoryIdForAdd { get; set; }
        public static int SubCategoryIdForAdd { get; set; }

        public static int SelectedCategoryId { get; set; }
        public static int SelectedSubCategoryId { get; set; }
        public static ObjectiveAndOutcomes objective { get; set; }
    }
}
