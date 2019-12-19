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
        
        void AddClassTeacher(string id, TeacherInputModel teacherModel);

        ClassViewModel EditClass(string id, ClassInputModel inputModel);
    }
}