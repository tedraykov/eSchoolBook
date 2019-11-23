using System.ComponentModel.DataAnnotations;

namespace SchoolBook.BusinessLogicLayer.DTOs.InputModels
{
    public class RegisterInputModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SecondName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string RoleId { get; set; }
    }
}
