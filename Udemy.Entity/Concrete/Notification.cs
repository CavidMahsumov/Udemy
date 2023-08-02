using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Entity.Concrete
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string SendUserId { get; set; }
        public string Content { get; set; }
    }
}
