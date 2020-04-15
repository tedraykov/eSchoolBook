using System.ComponentModel.DataAnnotations;

namespace SchoolBook.BusinessLogicLayer.DTOs.InputModels
{
    public class GradeInputModel
    {
        [Required]
        public string GradeId { get; set; }

        [Required]
        public string SubjectId { get; set; }
        
        [Required]
        public string TeacherId { get; set; }
    }
}