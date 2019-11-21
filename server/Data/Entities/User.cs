using Microsoft.AspNetCore.Identity;

namespace SchoolBook.Data.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public RoleTypes Role { get; set; }
    }
}