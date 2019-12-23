using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels.SchoolUsers;

namespace SchoolBook.BusinessLogicLayer.Interfaces
{
    public interface IClassService
    {
        List<ClassViewModel> GetAll();
        
        List<ClassViewModel>  GetAllByGrade (int grade);

        ClassViewModel GetOne(string id);

        void AddClass(ClassInputModel inputModel);
        
        void AddClassTeacher(string classId, string teacherId);
        
        void AddSubject(string classId, ClassToSubjectInputModel inputModel);
        
        void EditSubject(string classId, ClassToSubjectInputModel inputModel);
        
        void RemoveSubject(string classId, string subjectId);

        ClassViewModel EditClass(string id, ClassInputModel inputModel);
    }
}