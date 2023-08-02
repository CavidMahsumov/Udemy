using Microsoft.AspNetCore.Mvc;
using Udemy.Business.Abstract;
using Udemy.WebUI.Models;

namespace Udemy.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private ICategoryService _service;
        private ISubCategoryService _subCategoryService;
        private ITopicService _topicService;
        private ICourseService _courseService;

        public HomeController(ICategoryService service, ISubCategoryService subCategoryService, ITopicService topicService, ICourseService courseService)
        {
            _service = service;
            _subCategoryService = subCategoryService;
            _topicService = topicService;
            _courseService = courseService;
        }

        public IActionResult Index()
        {
            return View(new LayoutViewModel { Categories=_service.GetAll(),SubCategories=_subCategoryService.GetAll(),Topics=_topicService.GetAll(),Courses=_courseService.GetAll()});
        }



    }
}
