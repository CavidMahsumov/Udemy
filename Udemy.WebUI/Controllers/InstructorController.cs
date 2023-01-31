using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using Udemy.Business.Abstract;
using Udemy.Business.Concrete;
using Udemy.Entity.Concrete;
using Udemy.WebUI.Helper;
using Udemy.WebUI.Identity;
using Udemy.WebUI.Models;
using Udemy.WebUI.Service;

namespace Udemy.WebUI.Controllers
{
    [Authorize(Roles = "User,Admin")]
    public class InstructorController : Controller
    {

        private UserManager<User> _userManager;
        private ICourseService _courseService;
        private IVideoService _videoService;
        private ICategoryService _categoryService;
        private ISubCategoryService _subCategoryService;
        private ITopicService _topicService;
        private ITeacherService _teacherService;
        private int selectedcategoryid;
        private IHttpContextAccessor httpContextAccessor;
        private IWebHostEnvironment webHost;

        private readonly IStorageService _storageService;
        private readonly IConfiguration _configuration;
        Uri coursephotouri = null;

        public InstructorController(UserManager<User> userManager, ICourseService courseService, IVideoService videoService, ISubCategoryService subCategoryService, ITopicService topicService, ICategoryService categoryService, IWebHostEnvironment webHost, IHttpContextAccessor httpContextAccessor, ITeacherService teacherService, IStorageService storageService, IConfiguration configuration)
        {
            _userManager = userManager;
            _courseService = courseService;
            _videoService = videoService;
            _subCategoryService = subCategoryService;
            _topicService = topicService;
            _categoryService = categoryService;
            this.webHost = webHost;
            this.httpContextAccessor = httpContextAccessor;
            _teacherService = teacherService;
            _storageService = storageService;
            _configuration = configuration;
        }

        private async Task<User> GetCurrentUser()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }

        public JsonResult ReturnJsonSubCategories(int categoryId)
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true
            };

            if (categoryId > 0)
            {
                ClassHelper.SelectedCategoryId = categoryId;
            }
            var category = _categoryService.GetById(ClassHelper.SelectedCategoryId);
            var jsonData = _subCategoryService.GetAll().Where(sc => sc.Category == category).ToList();
            return Json(jsonData, options);
        }

        public JsonResult ReturnJsonTopics(int subCategoryId)
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true
            };

            if (subCategoryId > 0)
            {
                ClassHelper.SelectedSubCategoryId = subCategoryId;
            }
            var subCategory = _subCategoryService.GetById(ClassHelper.SelectedSubCategoryId);
            var jsonData = _topicService.GetAll().Where(sc => sc.SubCategory == subCategory).ToList();
            return Json(jsonData, options);
        }

        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> Index()
        {
            return View(new UserViewModel { User = await GetCurrentUser() });
        }


        [Authorize(Roles = "User,Admin")]
        [HttpGet]
        public async Task<IActionResult> CreateCourse()
        {

            TeacherAccountViewModel us = new TeacherAccountViewModel
            {
                Categories = _categoryService.GetAll()
            };
            us.SubCategories = _subCategoryService.GetAll();
            return View(us);
        }

        [Authorize(Roles = "User,Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateCourse(TeacherAccountViewModel model, IFormFile file)
        {
            var userId = httpContextAccessor.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            
            foreach (var teacher in _teacherService.GetAll())
            {
                if (teacher.MyUserId == user.Id)
                {

                    Course c = new Course();
                    if (file != null)
                    {
                        c.ImageUrl = file.FileName;
                        //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Image", file.FileName);

                        //using (var stream = new FileStream(path, FileMode.Create))
                        //{
                        //    await file.CopyToAsync(stream);
                        //}
                        model.CourseViewModel.ImagePath = file.FileName;
                        coursephotouri =await _storageService.UploadPhoto(file);
                        
                    }

                    c.CourseTitle = model.CourseViewModel.CourseTitle;
                    c.CourseContent = model.CourseViewModel.CourseContent;
                    c.Description = model.CourseViewModel.Description;
                    if (model.CourseViewModel.PaidOrFree == "Paid")
                    {
                        c.PaidOrFree = true;
                        c.Price = model.CourseViewModel.Price;
                    }
                    else if (model.CourseViewModel.PaidOrFree == "Free")
                    {
                        c.PaidOrFree = false;
                        c.Price = 0;
                    }

                    foreach (var category in _categoryService.GetAll())
                    {
                        if (category.CategoryName == model.CourseViewModel.CategoryName)
                        {
                            c.Category = category;
                            c.CategoryId = category.CategoryId;
                        }
                    }

                    foreach (var subCategory in _subCategoryService.GetAll())
                    {
                        if (subCategory.SubCategoryName == model.CourseViewModel.SubCategoryName)
                        {
                            c.SubCategory = subCategory;
                            c.SubCategoryId = subCategory.SubCategoryId;
                        }
                    }


                    foreach (var topic in _topicService.GetAll())
                    {
                        if (topic.TopicName == model.CourseViewModel.TopicName)
                        {
                            c.Topic = topic;
                            c.TopicId = topic.TopicId;
                        }
                    }

                    c.ObjectivesAndOutcomes = new List<ObjectiveAndOutcomes>
                {
                    new ObjectiveAndOutcomes
                    {
                        Content="Nicat get de qardasimsan"
                    },
                    new ObjectiveAndOutcomes
                    {
                        Content="Nicat get de qardasimsan"
                    },
                    new ObjectiveAndOutcomes
                    {
                        Content="Nicat get de qardasimsan"
                    },

                    new ObjectiveAndOutcomes
                    {
                        Content="Nicat get de qardasimsan"
                    },
                    new ObjectiveAndOutcomes
                    {
                        Content="Nicat get de qardasimsan"
                    },
                    new ObjectiveAndOutcomes
                    {
                        Content="Nicat get de qardasimsan"
                    },
                    new ObjectiveAndOutcomes
                    {
                        Content="Nicat get de qardasimsan"
                    },
                    new ObjectiveAndOutcomes
                    {
                        Content="Nicat get de qardasimsan"
                    },
                    new ObjectiveAndOutcomes
                    {
                        Content="Nicat get de qardasimsan"
                    },
                    new ObjectiveAndOutcomes
                    {
                        Content="Nicat get de qardasimsan"
                    },
                    new ObjectiveAndOutcomes
                    {
                        Content="Nicat get de qardasimsan"
                    },
                    new ObjectiveAndOutcomes
                    {
                        Content="Nicat get de qardasimsan"
                    },
                    new ObjectiveAndOutcomes
                    {
                        Content="Nicat get de qardasimsan"
                    },
                };

                    c.CourseVideos = new List<Video>
                {
                    new Video
                    {
                        Url="ASDFGHJKL"
                    },
                    new Video
                    {
                        Url="ASDFGHJKL"
                    },
                    new Video
                    {
                        Url="ASDFGHJKL"
                    },
                    new Video
                    {
                        Url="ASDFGHJKL"
                    },
                    new Video
                    {
                        Url="ASDFGHJKL"
                    },
                    new Video
                    {
                        Url="ASDFGHJKL"
                    },
                    new Video
                    {
                        Url="ASDFGHJKL"
                    },
                    new Video
                    {
                        Url="ASDFGHJKL"
                    },
                    new Video
                    {
                        Url="ASDFGHJKL"
                    },
                    new Video
                    {
                        Url="ASDFGHJKL"
                    },
                    new Video
                    {
                        Url="ASDFGHJKL"
                    }
                };


                    c.Teacher = teacher;
                    c.TeacherId = teacher.TeacherId;
                }
            }
            return RedirectToAction("Home", "Index");
        }


        public IActionResult MyCourses()
        {
            return View();
        }

    }



}

