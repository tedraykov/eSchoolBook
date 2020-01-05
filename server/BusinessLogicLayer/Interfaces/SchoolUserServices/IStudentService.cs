using System.Collections;
using System.Collections.Generic;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels.SchoolUsers;

namespace SchoolBook.BusinessLogicLayer.Interfaces.SchoolUserServices
{
    public interface IStudentService
    {
        string AddStudent(StudentInputModel studentModel);
        void UpdateStudent(string studentId, StudentInputModel studentModel);
        StudentInputModel GetStudent(string id);
        IEnumerable<StudentInputModel> GetAllStudents();
    }
}
