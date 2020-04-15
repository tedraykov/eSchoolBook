using System.Threading.Tasks;
using SchoolBook.BusinessLogicLayer.DTOs.Models.SchoolUserModels;
using System.Collections;
using System.Collections.Generic;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels.SchoolUsers.Teacher;

namespace SchoolBook.BusinessLogicLayer.Interfaces.SchoolUserServices
{
    public interface ITeacherService
    {
        Task AddTeacher(TeacherModel teacher);

        IEnumerable<TeacherTableViewModel> GetAllTeachersFromSchool(string schoolId);
        
        IEnumerable<MinimalSchoolUserModel> GetAllTeachersFromSchoolDropdown(string schoolId);
        
        IEnumerable<MinimalSchoolUserModel> GetTeachersListFromSubject(string subjectId);

        IEnumerable<MinimalSchoolUserModel> GetAllUnassignedToClass(string schoolId);
        
        TeacherDialogViewModel GetTeacherDialogData(string teacherId);
    }
}