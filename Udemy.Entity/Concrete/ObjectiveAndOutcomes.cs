using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Entity.Concrete
{
    public class ObjectiveAndOutcomes
    {
        public int ObjectiveAndOutcomesId { get; set; }
        public string Content { get; set; }
        public Course Course { get; set; }
    }
}
