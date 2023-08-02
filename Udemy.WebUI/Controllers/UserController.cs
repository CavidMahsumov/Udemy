using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Udemy.Business.Abstract;
using Udemy.Entity.Concrete;
using Udemy.WebUI.Identity;
using Udemy.WebUI.Models;

namespace Udemy.WebUI.Controllers
{
    [Authorize(Roles = "User,Admin")]
    public class UserController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private ICategoryService _categoryService;
        private ICourseService _courseService;
        private ITeacherService _teacherService;
        private ICartService _cartService;
        private string CurrentUserId;
        public Cart Cart { get; set; }

        public UserController(ICategoryService service, ICourseService courseService, UserManager<User> userManager, SignInManager<User> signInManager, ITeacherService teacherService, IHttpContextAccessor httpContextAccessor)
        {
            _categoryService = service;
            _courseService = courseService;
            _userManager = userManager;
            _signInManager = signInManager;
            _teacherService = teacherService;
            Cart = new Cart();

            CurrentUserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }


        private async Task<User> GetCurrentUser(string currentId)
        {
            return await _userManager.FindByIdAsync(currentId);
        }

        [Authorize(Roles = "User,Admin")]
        public IActionResult Index(bool? adminoruser)
        {
            return View(new UserViewModel { Courses = _courseService.GetAll(), Categories = _categoryService.GetAll(), AdminOrUser = adminoruser });
        }

        [Authorize(Roles = "User,Admin")]
        public IActionResult CourseDetails()
        {
            return View(new UserViewModel { Categories = _categoryService.GetAll() });
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet]
        public async Task<IActionResult> AddTeacherAccount()
        {
            foreach (var teacher in _teacherService.GetAll())
            {
                if (teacher.MyUserId == CurrentUserId)
                {
                    return RedirectToAction("Index", "Instructor");
                }

            }
            return View(new UserViewModel { User = await GetCurrentUser(CurrentUserId) });
        }
        [Authorize(Roles = "User,Admin")]
        [HttpPost]
        public async Task<IActionResult> AddTeacherAccount(UserViewModel model)
        {
            Teacher t = new Teacher
            {
                FullName = model.TeacherFullName,
                MyUserId = model.TeacherAccount.MyId,
                FieldOfWork = model.TeacherAccount.MyTeacherAccount.FieldOfWork,
                AboutMe = model.TeacherAccount.MyTeacherAccount.AboutMe
            };
            _teacherService.Add(t);
            return RedirectToAction("Index", "Instructor");


        }
        public async Task<IActionResult> AddToCart(Course course)
        {
  
           
            _cartService.AddToCart(Cart,course);
            return RedirectToAction("Index", "Cart");
         
            
            
            
        }

        public IActionResult  ShowCart(CartListViewModel model)
        {

            //var model=new CartListViewModel
            //{
            //     Courses=
            //}
            return RedirectToAction("Index", "Cart");
        }
    }
}
