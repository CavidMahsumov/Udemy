using Microsoft.AspNetCore.Mvc;

namespace Udemy.WebUI.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
