using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Udemy.Entity.Concrete;

namespace Udemy.DataAccess.Concrete.EntityFramework
{
    public class UdemyContext : DbContext
    {
        public UdemyContext(DbContextOptions<UdemyContext> options)
            : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<ObjectiveAndOutcomes> Objectives { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<CourseNotification> CourseNotifications { get; set; }
        public DbSet<AdminNotification> AdminNotifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //modelBuilder.Entity<ObjectiveAndOutcomes>().HasOne(a => a.Course).WithMany(b => b.ObjectivesAndOutcomes);
            //modelBuilder.Entity<Requirement>().HasOne(a => a.Course).WithMany(b => b.Requirements);
            //modelBuilder.Entity<Video>().HasOne(a => a.Course).WithMany(b => b.CourseVideos);
            //modelBuilder.Entity<Comment>().HasOne(a => a.Course).WithMany(b => b.CourseComments);
            //modelBuilder.Entity<SubCategory>().HasOne(a => a.Category).WithMany(b => b.SubCategories);
            //modelBuilder.Entity<Topic>().HasOne(a => a.SubCategory).WithMany(b => b.Topics);


            //modelBuilder.Entity<Category>().HasData(new Category
            //{
            //    CategoryName = "Development"
            //},new Category
            //{
            //    CategoryName="Design"
            //});



            //modelBuilder.Entity<SubCategory>().HasData(new SubCategory
            //{
                
            //    Category = 1,
            //    SubCategoryName = "Web Development"
            //},
            //new SubCategory
            //{
            //    CategoryId=2,
            //    SubCategoryName="Web Design"
            //});

            modelBuilder.Entity<SubCategory>().HasOne(p => p.Category).WithMany(b => b.SubCategories)
    .HasForeignKey(p => p.SubCategoryId)
    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Topic>().HasOne(p => p.SubCategory).WithMany(b => b.Topics)
    .HasForeignKey(p => p.TopicId)
    .OnDelete(DeleteBehavior.Cascade);


            


            base.OnModelCreating(modelBuilder);

        }

    }
}
