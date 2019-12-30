using System.Collections.Generic;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels.SchoolUsers.Edit;
using SchoolBook.BusinessLogicLayer.DTOs.Models.SchoolUserModels;

namespace SchoolBook.BusinessLogicLayer.Interfaces.SchoolUserServices
{
    public interface IStudentService
    {
        IEnumerable<StudentModel> GetAllStudents();
        
        IEnumerable<StudentModel> GetAllStudentsFromSchool(string schoolId);
        
        IEnumerable<StudentModel> GetAllStudentsFromClass(string classId);
        
        StudentModel GetStudent(string id);

        void AddStudent(StudentModel studentModel);
        
        void UpdateStudent(string studentId, StudentEditInputModel studentModel);

        void GradeStudent(string studentId, GradeInputModel gradeModel);
        
        void EditGrade(string gradeId, string newGradeId);
        
        void RemoveGrade(string gradeId);

        void AddAbsenceToStudent(string studentId, AbsenceInputModel absenceModel);
        
        void ExcuseStudentAbsence(string studentId, string absenceId);

        void RemoveStudent(string studentId);
    }
}
