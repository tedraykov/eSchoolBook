using System.Collections.Generic;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels.SchoolUsers;

namespace SchoolBook.BusinessLogicLayer.Interfaces
{
    public interface ICurriculumService
    {
        List<T_ClassToSubjectViewModel> GetTeacherActiveSubjects(string teacherId);

        List<StudentViewModel> GetStudentsInClassAttendingSubject(string classCurriculumId);

        List<S_ClassToSubjectViewModel> GetStudentWeeklyCurriculum(string studentId);
    }
}