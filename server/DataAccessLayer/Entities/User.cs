using Microsoft.AspNetCore.Identity;
using SchoolBook.BusinessLogicLayer.DTOs.Enums;
using SchoolBook.Data;

namespace SchoolBook.DataAccessLayer.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public RoleTypes Role { get; set; }
    }
}
