using Udemy.Business.Abstract;
using Udemy.Entity.Concrete;
using Udemy.WebUI.Identity;

namespace Udemy.WebUI.Helper
{
    public static class ClassHelper
    {
        public static int CategoryIdForAdd { get; set; }
        public static int SubCategoryIdForAdd { get; set; }

        public static int SelectedCategoryId { get; set; }
        public static int SelectedSubCategoryId { get; set; }
        public static ObjectiveAndOutcomes objective { get; set; }

        public static int  RoleId { get; set; }
        public static string UserId { get; set; }



        public static string SearchForUser { get; set; }

    }
}
