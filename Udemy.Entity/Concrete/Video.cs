using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Entity.Concrete
{
    public class Video
    {
        public int VideoId { get; set; }
        public string VideoImageUrl { get; set; }
        public string Url { get; set; }
        public string LessonTitle { get; set; }
        public string LessonOutcomes { get; set; }
        public Course Course { get; set; }
    }
}
