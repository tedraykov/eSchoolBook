using System.Collections.Generic;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels.SchoolUsers;

namespace SchoolBook.BusinessLogicLayer.Interfaces
{
    public interface ICurriculumService
    {
        List<ClassToSubjectViewModel> GetTeacherActiveSubjects(string teacherId);

        List<StudentViewModel> GetStudentsInClassAttendingSubject(string classCurriculumId);
    }
}