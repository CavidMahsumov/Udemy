using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Entity.Concrete
{
    public class Topic
    {
        public int TopicId { get; set; }
        public string TopicName { get; set; }

        public SubCategory SubCategory { get; set; }

        public ICollection<Course> Courses { get; set; }


    }
}
