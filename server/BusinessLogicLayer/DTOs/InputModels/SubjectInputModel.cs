using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolBook.BusinessLogicLayer.DTOs.InputModels
{
    public class SubjectInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Signature { get; set; }

        [Required]
        [Range(1,12)]
        public int GradeYear { get; set; }
    }
}