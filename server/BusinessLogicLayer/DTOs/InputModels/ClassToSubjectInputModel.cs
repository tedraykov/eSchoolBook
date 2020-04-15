using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolBook.BusinessLogicLayer.DTOs.InputModels
{
    public class ClassToSubjectInputModel
    {
        [Required]
        public string SubjectId { get; set; }
        
        [Required]
        public string TeacherId { get; set; }
        
        [Required]
        public string WeekDay { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }
    }
}