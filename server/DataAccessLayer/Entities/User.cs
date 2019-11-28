using Microsoft.AspNetCore.Identity;
using SchoolBook.BusinessLogicLayer.DTOs.Enums;

namespace SchoolBook.DataAccessLayer.Entities
{
    public class User : IdentityUser
    {
        public RoleTypes Role { get; set; }
    }
}
