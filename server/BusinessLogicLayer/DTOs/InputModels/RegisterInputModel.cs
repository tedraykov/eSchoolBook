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
        public string RoleName { get; set; }
    }
}
