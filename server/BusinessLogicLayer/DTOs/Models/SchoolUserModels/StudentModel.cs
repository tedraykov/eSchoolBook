using System.ComponentModel.DataAnnotations;

namespace SchoolBook.BusinessLogicLayer.DTOs.Models.SchoolUserModels
{
    public class StudentModel : SchoolUserModel
    {
        [Required] 
        public string ClassId { get; set; }

        [Required] 
        public int StartYear { get; set; }
    }
}
