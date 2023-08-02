using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using Udemy.Business.Abstract;
using Udemy.Business.Concrete;
using Udemy.DataAccess.Abstract;
using Udemy.DataAccess.Concrete;
using Udemy.DataAccess.Concrete.EntityFramework;
using Udemy.WebUI.Identity;
using Udemy.WebUI.Service;
using Udemy.WebUI.Service.CloudinaryService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ITopicRepository, TopicRepository>();
builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IObjectiveRepository, ObjectiveRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IVideoRepository, VideoRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IRequirementRepository, RequirementRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<ICourseNotificationRepository, CourseNotificationRepository>();
builder.Services.AddScoped<IAdminNotificationRepository, AdminNotificationRepository>();


builder.Services.AddScoped<ITopicService, TopicManager>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICommentService, CommentManager>();
builder.Services.AddScoped<IObjectiveService, ObjectiveManager>();
builder.Services.AddScoped<ICourseService, CourseManager>();
builder.Services.AddScoped<IVideoService, VideoManager>();
builder.Services.AddScoped<ITeacherService, TeacherManager>();
builder.Services.AddScoped<IRequirementService, RequirementManager>();
builder.Services.AddScoped<IStorageService, StorageService>();
builder.Services.AddScoped<ICloudinaryService, CloudinaryService>();
builder.Services.AddScoped<INotificationService, NotificationManager>();
builder.Services.AddScoped<ICourseNotificationService, CourseNotificationManager>();
builder.Services.AddScoped<IAdminNotificationService, AdminNotificationManager>();
//builder.Services.AddScoped<IEmailSender, HotmailEmailSender>();

builder.Services.AddDbContext<UdemyContext>(options => options.UseSqlServer(

    @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Udemy;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"

    ));
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(

    @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Udemy;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"

    ));
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;

    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.AllowedForNewUsers = true;

    options.User.RequireUniqueEmail = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
}


);

builder.Services.AddSession();

builder.Services.ConfigureApplicationCookie(options => {
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccesDenied";
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(10);
    options.Cookie = new CookieBuilder()
    {
        HttpOnly = true,
        Name = ".Udemy.Security.Cookie"

    };

});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.UseSession();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();