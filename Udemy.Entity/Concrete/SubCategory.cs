using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Entity.Concrete
{
    public class SubCategory
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public Category Category { get; set; }
        public ICollection<Topic> Topics { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
