using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Entity.Concrete
{
    public class Requirement
    {
        public int RequirementId { get; set; }
        public string Content { get; set; }
        public Course Course { get; set; }
    }
}
