using System.Collections.Generic;
using SchoolBook.DataAccessLayer.Entities;

namespace SchoolBook.BusinessLogicLayer.DTOs.ViewModels.SchoolUsers.Teacher
{
    public class TeacherDialogViewModel : TeacherTableViewModel
    {
        public string Email { get; set; }

        public ICollection<SubjectOnlyViewModel> Subjects { get; set; }

        public double AvgScore { get; set; }
    }
}