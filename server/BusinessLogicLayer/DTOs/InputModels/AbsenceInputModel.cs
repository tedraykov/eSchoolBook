using System.ComponentModel.DataAnnotations;

namespace SchoolBook.BusinessLogicLayer.DTOs.InputModels
{
    public class AbsenceInputModel
    {
        [Required]
        public bool IsFullAbsence { get; set; }

        [Required]
        public string SubjectId { get; set; }
        
        [Required]
        public string TeacherId { get; set; }
        
    }
}