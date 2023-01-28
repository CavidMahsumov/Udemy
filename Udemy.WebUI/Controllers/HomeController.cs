using Microsoft.AspNetCore.Mvc;
using Udemy.Business.Abstract;
using Udemy.WebUI.Models;

namespace Udemy.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private ICategoryService _service;

        public HomeController(ICategoryService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(new LayoutViewModel { Categories=_service.GetAll()});
        }



    }
}
