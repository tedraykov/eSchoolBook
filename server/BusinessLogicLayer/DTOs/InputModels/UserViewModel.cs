using SchoolBook.BusinessLogicLayer.DTOs.Enums;

namespace SchoolBook.BusinessLogicLayer.DTOs.InputModels
{
    public class UserViewModel
    {
        public string SchoolUserId { get; set; }
        public string FirstName { get; set; }
        public RoleTypes Role { get; set; }
    }
}