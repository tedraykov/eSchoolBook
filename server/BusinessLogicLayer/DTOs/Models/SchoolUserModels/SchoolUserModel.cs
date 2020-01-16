using System.ComponentModel.DataAnnotations;

namespace SchoolBook.BusinessLogicLayer.DTOs.Models.SchoolUserModels
{
    public class SchoolUserModel
    {
        [Required] 
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        [Required] 
        public string LastName { get; set; }

        [Required] 
        public string Pin { get; set; }

        [Required] 
        public string Address { get; set; }

        [Required]
        public string Town { get; set; }

        [Required] 
        public string SchoolId { get; set; }
    }
}
