using System.Collections.Generic;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels;

namespace SchoolBook.BusinessLogicLayer.Interfaces
{
    public interface IClassService
    {
        List<ClassViewModel> GetAll();
        List<ClassViewModel> GetAllBySchool(string schoolId);
        
        List<ClassViewModel>  GetAllByGrade (int grade);

        List<MinimalClassViewModel> GetClassesWithoutClassTeacher(string schoolId);

        ClassViewModel GetOne(string id);

        void AddClass(ClassInputModel inputModel);
        
        void AddClassTeacher(string classId, string teacherId);
        
        void AddSubject(string classId, ClassToSubjectInputModel inputModel);
        
        void EditSubject(string classId, ClassToSubjectInputModel inputModel);
        
        void RemoveSubject(string classId, string subjectId);

        ClassViewModel EditClass(string id, ClassInputModel inputModel);
    }
}