using System.ComponentModel.DataAnnotations;

namespace SchoolBook.BusinessLogicLayer.DTOs.InputModels.SchoolUsers
{
    public class StudentInputModel : SchoolUserInputModel
    {
        [Required] public string ClassId { get; set; }

        [Required] public string StartYear { get; set; }
    }
}
