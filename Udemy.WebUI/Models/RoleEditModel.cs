using Microsoft.AspNetCore.Identity;
using Udemy.WebUI.Identity;

namespace Udemy.WebUI.Models
{
    public class RoleEditModel
    {
        public IdentityRole Role { get; set; }
        public List<User> Members { get; set; }
        public List<User> NonMembers { get; set; }

    }
}
