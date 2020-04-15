using System.Collections.Generic;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels.SchoolUsers;

namespace SchoolBook.BusinessLogicLayer.Interfaces
{
    public interface ISchoolService
    {
        ICollection<SchoolViewModel> GetAll();

        SchoolViewModel GetOneById(string schoolId);

        void AddSchool(SchoolInputModel inputModel);

        void EditSchool(string schoolId, SchoolInputModel inputModel);

        void DeleteSchool(string schoolId);
    }
}
