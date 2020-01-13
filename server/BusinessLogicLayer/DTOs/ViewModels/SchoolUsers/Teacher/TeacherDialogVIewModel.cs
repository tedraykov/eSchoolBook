using System.Collections.Generic;

namespace SchoolBook.BusinessLogicLayer.DTOs.ViewModels.SchoolUsers.Teacher
{
    public class TeacherDialogViewModel : TeacherTableViewModel
    {
        public string Email { get; set; }

        public ICollection<SubjectOnlyViewModel> Subjects { get; set; }
    }
}