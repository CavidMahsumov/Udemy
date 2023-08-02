using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Udemy.Business.Abstract;
using Udemy.WebUI.Service.CartService;

namespace Udemy.WebUI.Controllers
{
    public class CartController : Controller
    {
        private ICartSessionService _cartSessionService;
        private ICartService _cartService;
        private ICourseService _courseService;
        public IActionResult Index()
        {
            return View();
        }
    }
}
