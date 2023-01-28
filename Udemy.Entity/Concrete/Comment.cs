using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Entity.Concrete
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }

    }
}
