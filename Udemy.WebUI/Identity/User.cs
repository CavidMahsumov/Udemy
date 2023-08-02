using Microsoft.AspNetCore.Identity;
using Udemy.Entity.Concrete;

namespace Udemy.WebUI.Identity
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MyTeacherProfileId { get; set; }
        public string ImageUrl { get; set; }

    }
}
