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
        private INotificationService _notificationService;
        private ICourseNotificationService _courseNotificationService;
        private IAdminNotificationService _adminNotificationService;

        private int selectedcategoryid;
        private IHttpContextAccessor httpContextAccessor;
        private IWebHostEnvironment webHost;

        private readonly IStorageService _storageService;
        private readonly IConfiguration _configuration;
        Uri coursephotouri = null;

        public InstructorController(UserManager<User> userManager, ICourseService courseService, IVideoService videoService, ISubCategoryService subCategoryService, ITopicService topicService, ICategoryService categoryService, IWebHostEnvironment webHost, IHttpContextAccessor httpContextAccessor, ITeacherService teacherService, IStorageService storageService, IConfiguration configuration, INotificationService notificationService, ICourseNotificationService courseNotificationService, IAdminNotificationService adminNotificationService)
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
            _notificationService = notificationService;
            _courseNotificationService = courseNotificationService;
            _adminNotificationService = adminNotificationService;
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
        public async Task<IActionResult> CreateCourse(TeacherAccountViewModel model, IFormFile file, List<ObjectiveAndOutcomes> objectives, List<Requirement> requirements)
        {
            var userId = httpContextAccessor.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);

            var category = _categoryService.GetById(ClassHelper.SelectedCategoryId);
            var subcategory = _subCategoryService.GetById(ClassHelper.SelectedSubCategoryId);
            var topic = _topicService.GetById(model.CourseViewModel.TopicId);

            foreach (var teacher in _teacherService.GetAll())
            {
                if (teacher.MyUserId == user.Id)
                {

                    Course c = new Course();
                    if (file != null)
                    {

                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images", file.FileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        model.CourseViewModel.ImagePath = "~/Images/" + file.FileName;
                        coursephotouri = await _storageService.UploadPhoto(file);
                        TempData.Add("Image", coursephotouri.ToString());
                        c.ImageUrl = coursephotouri.ToString();
                    }
                    c.ImageUrl = "asdfghjkl";

                    c.CourseTitle = model.CourseViewModel.CourseTitle;
                    c.CourseContent = model.CourseViewModel.CourseContent;
                    c.Description = model.CourseViewModel.Description;

                    c.PaidOrFree = true;
                    c.Price = model.CourseViewModel.Price;




                    c.Category = category;
                    c.CategoryId = category.CategoryId;

                    c.SubCategory = subcategory;
                    c.SubCategoryId = subcategory.SubCategoryId;




                    c.Topic = topic;
                    c.TopicId = topic.TopicId;


                    c.ObjectivesAndOutcomes = objectives;
                    c.Requirements = requirements;


                    //kndhvsghvxcsgvcxsahcjsbacskjsn jn hwbuhww

                    c.CourseVideos = new List<Video>
                {
                    new Video
                    {
                        LessonTitle="ders",
                        LessonOutcomes="Identity",
                        Url="ASDFGHJKL",
                        VideoImageUrl="asdfghjk"
                    },
                    new Video
                    {
                        LessonTitle="ders",
                        LessonOutcomes="Identity",
                        Url="ASDFGHJKL",
                        VideoImageUrl="asdfghjk"
                    },new Video
                    {
                        LessonTitle="ders",
                        LessonOutcomes="Identity",
                        Url="ASDFGHJKL",
                        VideoImageUrl="asdfghjk"
                    },new Video
                    {
                        LessonTitle="ders",
                        LessonOutcomes="Identity",
                        Url="ASDFGHJKL",
                        VideoImageUrl="asdfghjk"
                    },new Video
                    {
                        LessonTitle="ders",
                        LessonOutcomes="Identity",
                        Url="ASDFGHJKL",
                        VideoImageUrl="asdfghjk"
                    },new Video
                    {
                        LessonTitle="ders",
                        LessonOutcomes="Identity",
                        Url="ASDFGHJKL",
                        VideoImageUrl="asdfghjk"
                    },new Video
                    {
                        LessonTitle="ders",
                        LessonOutcomes="Identity",
                        Url="ASDFGHJKL",
                        VideoImageUrl="asdfghjk"
                    },new Video
                    {
                        LessonTitle="ders",
                        LessonOutcomes="Identity",
                        Url="ASDFGHJKL",
                        VideoImageUrl="asdfghjk"
                    }
                };


                    c.Teacher = teacher;
                    c.TeacherId = teacher.TeacherId;

                    c.isAccepted = false;

                    var n = new Notification
                    {
                        SendUserId = user.Id,
                        Content = "New Course"
                    };


                    var cn = new CourseNotification
                    {
                        Notification = n,
                        Course = c
                    };


                    AdminNotification an = new AdminNotification();

                    an.CourseNotifications.Add(cn);
                    an.Courses.Add(cn.Course);


                    _courseService.Add(c);
                    _notificationService.Add(n);
                    _courseNotificationService.Add(cn);
                    _adminNotificationService.Add(an);
                    TempData.Add("message", "Course was sended to Admin! Please wait for Admin answer . . .");

                }
            }
            return RedirectToAction("Index", "Instructor");
        }


        public IActionResult MyCourses()
        {
            return View();
        }

    }



}

