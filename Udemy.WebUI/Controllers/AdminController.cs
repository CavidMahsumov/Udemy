using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Udemy.Business.Abstract;
using Udemy.Entity.Concrete;
using Udemy.WebUI.Helper;
using Udemy.WebUI.Identity;
using Udemy.WebUI.Models;

namespace Udemy.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;


        private ICategoryService _categoryService;
        private ISubCategoryService _subCategoryService;
        private ITopicService _topicService;

        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, ICategoryService categoryService, ISubCategoryService subCategoryService, ITopicService topicService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
            _topicService = topicService;
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View(new AdminViewModel { Categories = _categoryService.GetAll() });
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RoleEdit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            var members = new List<User>();
            var nonMembers = new List<User>();

            foreach (var user in _userManager.Users)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);

            }
            var model = new RoleEditModel
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            };

            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult RoleList()
        {
            return View(new AdminViewModel { Categories = _categoryService.GetAll(), RoleList = _roleManager.Roles.ToList() });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult RoleCreate()
        {
            return View(new AdminViewModel { Categories = _categoryService.GetAll() });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> RoleCreate(AdminViewModel model)
        {

            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole { Name = model.roleModel.Name });
                if (result.Succeeded)
                {
                    return RedirectToAction("RoleList", "Admin");
                }

            }
            TempData.Add("message", "Role was added successfully");
            return View(model);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult CategoryList()
        {
            return View(new AdminViewModel { Categories = _categoryService.GetAll() });
        }

        [Authorize(Roles = "Admin")]
        public IActionResult SubCategoryList(int categoryId)
        {
            if (categoryId > 0)
            {

                ClassHelper.CategoryIdForAdd = categoryId;
            }
            var category = _categoryService.GetById(ClassHelper.CategoryIdForAdd);
            return View(new AdminViewModel { SubCategories = _subCategoryService.GetAll().Where(c => c.Category == category).ToList() });
        }
        [Authorize(Roles = "Admin")]
        public IActionResult TopicList(int subCategoryId)
        {
            if(subCategoryId > 0)
            {
                ClassHelper.SubCategoryIdForAdd=subCategoryId;
            }
            var subcategory = _subCategoryService.GetById(ClassHelper.SubCategoryIdForAdd);
            return View(new AdminViewModel { Topics = _topicService.GetAll().Where(c => c.SubCategory == subcategory).ToList()/*,SubCategoryName=_subCategoryService.GetById(subCategoryId).SubCategoryName */});
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View(new AdminViewModel { Categories = _categoryService.GetAll() });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddCategory(AdminViewModel model)
        {
            var entity = new Category()
            {
                CategoryName = model.addCategoryModel.CategoryName
            };

            _categoryService.Add(entity);
            TempData.Add("message", "Category was added successfully");

            return RedirectToAction("CategoryList", "Admin");
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddSubCategory()
        {
            return View(new AdminViewModel { SubCategories = _subCategoryService.GetAll() });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddSubCategory(AdminViewModel model)
        {
            var category = _categoryService.GetById(ClassHelper.CategoryIdForAdd);
            var entity = new SubCategory()
            {
                SubCategoryName = model.addSubCategoryModel.Name,
                Category = category

            };

            _subCategoryService.Add(entity);
            TempData.Add("message", "SubCategory was added successfully");

            return RedirectToAction("SubCategoryList", "Admin");
        }



        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddTopic()
        {
            return View(new AdminViewModel { Topics = _topicService.GetAll() });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddTopic(AdminViewModel model)
        {
            var subCategory = _subCategoryService.GetById(ClassHelper.SubCategoryIdForAdd);
            var entity = new Topic()
            {
                TopicName = model.addTopicModel.Name,
                SubCategory = subCategory

            };

            _topicService.Add(entity);
            TempData.Add("message", "Topic was added successfully");

            return RedirectToAction("TopicList", "Admin");
        }









        [Authorize(Roles = "Admin")]
        public IActionResult RemoveCategory(int categoryId)
        {
            var entity = _categoryService.GetById(categoryId);
            _categoryService.Delete(entity);


            TempData.Add("message", "Category was removed successfully");

            return RedirectToAction("CategoryList", "Admin");
        }


        [Authorize(Roles = "Admin")]
        public IActionResult RemoveSubCategory(int subCategoryId)
        {
            var entity = _subCategoryService.GetById(subCategoryId);
            _subCategoryService.Delete(entity);


            TempData.Add("message", "SubCategory was removed successfully");

            return RedirectToAction("SubCategoryList", "Admin");
        }


        [Authorize(Roles = "Admin")]
        public IActionResult RemoveTopic(int topicId)
        {
            var entity = _topicService.GetById(topicId);
            _topicService.Delete(entity);


            TempData.Add("message", "Topic was removed successfully");

            return RedirectToAction("TopicList", "Admin");
        }



    }
}
