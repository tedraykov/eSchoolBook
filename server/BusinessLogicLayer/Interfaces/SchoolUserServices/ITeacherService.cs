using System.Collections;
using System.Collections.Generic;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels.SchoolUsers.Teacher;

namespace SchoolBook.BusinessLogicLayer.Interfaces.SchoolUserServices
{
    public interface ITeacherService
    {
        IEnumerable<TeacherTableViewModel> GetAllTeachersFromSchool(string schoolId);
    }
}