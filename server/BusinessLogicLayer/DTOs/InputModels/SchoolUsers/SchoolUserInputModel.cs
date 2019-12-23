using System.ComponentModel.DataAnnotations;

namespace SchoolBook.BusinessLogicLayer.DTOs.InputModels.SchoolUsers
{
    public class SchoolUserInputModel
    {
        [Required] public string FirstName { get; set; }

        public string SecondName { get; set; }

        [Required] public string LastName { get; set; }

        [Required] public string Pin { get; set; }

        [Required] public string Address { get; set; }

        [Required] public string Town { get; set; }

        public string SchoolId { get; set; }
    }
}
