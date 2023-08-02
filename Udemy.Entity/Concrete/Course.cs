using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Entity.Concrete
{
    public class Course
    {
        public int CourseId { get; set; }
        public string ImageUrl { get; set; }
        [ForeignKey("TeacherId")]
        public virtual Teacher Teacher { get; set; }
        [Required]
        public int TeacherId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("SubCategoryId")]
        public virtual SubCategory SubCategory { get; set; }
        [Required]
        public int SubCategoryId { get; set; }
        [ForeignKey("TopicId")]
        public virtual Topic Topic { get; set; }
        [Required]
        public int TopicId { get; set; }
        public string CourseTitle { get; set; }
        public string Description { get; set; }
        public string CourseContent { get; set; }
        public ICollection<ObjectiveAndOutcomes> ObjectivesAndOutcomes { get; set; }
        public ICollection<Requirement> Requirements { get; set; }
        public bool PaidOrFree { get; set; }
        public bool isAccepted { get; set; }
        public decimal? Price { get; set; }
        public ICollection<Video> CourseVideos { get; set; }
        public ICollection<Comment> CourseComments { get; set; }

    }
}
