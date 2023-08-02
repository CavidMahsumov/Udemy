﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Udemy.DataAccess.Concrete.EntityFramework;

#nullable disable

namespace Udemy.DataAccess.Migrations
{
    [DbContext(typeof(UdemyContext))]
    partial class UdemyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Udemy.Entity.Concrete.AdminNotification", b =>
                {
                    b.Property<int>("AdminNotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminNotificationId"));

                    b.HasKey("AdminNotificationId");

                    b.ToTable("AdminNotifications");
                });

            modelBuilder.Entity("Udemy.Entity.Concrete.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartId"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CartId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Udemy.Entity.Concrete.CartItem", b =>
                {
                    b.Property<int>("CartItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartItemId"));

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("CartItemId");

                    b.HasIndex("CartId");

                    b.HasIndex("CourseId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("Udemy.Entity.Concrete.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Udemy.Entity.Concrete.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("SendUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CommentId");

                    b.HasIndex("CourseId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Udemy.Entity.Concrete.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CourseContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PaidOrFree")
                        .HasColumnType("bit");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<int>("TopicId")
                        .HasColumnType("int");

                    b.Property<bool>("isAccepted")
                        .HasColumnType("bit");

                    b.HasKey("CourseId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SubCategoryId");

                    b.HasIndex("TeacherId");

                    b.HasIndex("TopicId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Udemy.Entity.Concrete.CourseNotification", b =>
                {
                    b.Property<int>("CourseNotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseNotificationId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("NotificationId")
                        .HasColumnType("int");

                    b.HasKey("CourseNotificationId");

                    b.HasIndex("CourseId");

                    b.HasIndex("NotificationId");

                    b.ToTable("CourseNotifications");
                });

            modelBuilder.Entity("Udemy.Entity.Concrete.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SendUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("NotificationId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Udemy.Entity.Concrete.ObjectiveAndOutcomes", b =>
                {
                    b.Property<int>("ObjectiveAndOutcomesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ObjectiveAndOutcomesId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("ObjectiveAndOutcomesId");

                    b.HasIndex("CourseId");

                    b.ToTable("Objectives");
                });

            modelBuilder.Entity("Udemy.Entity.Concrete.Requirement", b =>
                {
                    b.Property<int>("RequirementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequirementId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("RequirementId");

                    b.HasIndex("CourseId");

                    b.ToTable("Requirements");
                });

            modelBuilder.Entity("Udemy.Entity.Concrete.SubCategory", b =>
                {
                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("SubCategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubCategoryId");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("Udemy.Entity.Concrete.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"));

                    b.Property<string>("AboutMe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FieldOfWork")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MyStudentCount")
                        .HasColumnType("int");

                    b.Property<string>("MyUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Udemy.Entity.Concrete.Topic", b =>
                {
                    b.Property<int>("TopicId")
                        .HasColumnType("int");

                    b.Property<string>("TopicName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TopicId");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("Udemy.Entity.Concrete.Video", b =>
                {
                    b.Property<int>("VideoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VideoId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("LessonOutcomes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LessonTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VideoId");

                    b.HasIndex("CourseId");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("Udemy.Entity.Concrete.CartItem", b =>
                {
                    b.HasOne("Udemy.Entity.Concrete.Cart", null)
                        .WithMany("CartItem")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Udemy.Entity.Concrete.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Udemy.Entity.Concrete.Comment", b =>
                {
                    b.HasOne("Udemy.Entity.Concrete.Course", "Course")
                        .WithMany("CourseComments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Udemy.Entity.Concrete.Course", b =>
                {
                    b.HasOne("Udemy.Entity.Concrete.Category", "Category")
                        .WithMany("Courses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Udemy.Entity.Concrete.SubCategory", "SubCategory")
                        .WithMany("Courses")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Udemy.Entity.Concrete.Teacher", "Teacher")
                        .WithMany("MyCourses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Udemy.Entity.Concrete.Topic", "Topic")
                        .WithMany("Courses")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("SubCategory");

                    b.Navigation("Teacher");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("Udemy.Entity.Concrete.CourseNotification", b =>
                {
                    b.HasOne("Udemy.Entity.Concrete.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Udemy.Entity.Concrete.Notification", "Notification")
                        .WithMany()
                        .HasForeignKey("NotificationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Notification");
                });

            modelBuilder.Entity("Udemy.Entity.Concrete.Notification", b =>
                {
                    b.HasOne("Udemy.Entity.Concrete.Teacher", null)
                        .WithMany("Notifications")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Udemy.Entity.Concrete.ObjectiveAndOutcomes", b =>
                {
                    b.HasOne("Udemy.Entity.Concrete.Course", "Course")
                        .WithMany("ObjectivesAndOutcomes")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Udemy.Entity.Concrete.Requirement", b =>
                {
                    b.HasOne("Udemy.Entity.Concrete.Course", "Course")
                        .WithMany("Requirements")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Udemy.Entity.Concrete.SubCategory", b =>
                {
                    b.HasOne("Udemy.Entity.Concrete.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Udemy.Entity.Concrete.Topic", b =>
                {
                    b.HasOne("Udemy.Entity.Concrete.SubCategory", "SubCategory")
                        .WithMany("Topics")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("Udemy.Entity.Concrete.Video", b =>
                {
                    b.HasOne("Udemy.Entity.Concrete.Course", "Course")
                        .WithMany("CourseVideos")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Udemy.Entity.Concrete.Cart", b =>
                {
                    b.Navigation("CartItem");
                });

            modelBuilder.Entity("Udemy.Entity.Concrete.Category", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("Udemy.Entity.Concrete.Course", b =>
                {
                    b.Navigation("CourseComments");

                    b.Navigation("CourseVideos");

                    b.Navigation("ObjectivesAndOutcomes");

                    b.Navigation("Requirements");
                });

            modelBuilder.Entity("Udemy.Entity.Concrete.SubCategory", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Topics");
                });

            modelBuilder.Entity("Udemy.Entity.Concrete.Teacher", b =>
                {
                    b.Navigation("MyCourses");

                    b.Navigation("Notifications");
                });

            modelBuilder.Entity("Udemy.Entity.Concrete.Topic", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
