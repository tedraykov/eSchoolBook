using SchoolBook.BusinessLogicLayer.DTOs.InputModels;

namespace SchoolBook.BusinessLogicLayer.Interfaces
{
    public interface ISchoolService
    {
        void AddSchool(SchoolInputModel school);
    }
}
