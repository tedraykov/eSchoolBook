using System.Collections.Generic;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels;

namespace SchoolBook.BusinessLogicLayer.Interfaces
{
    public interface ISchoolUserService
    {
        UserViewModel GetSchoolUserBaseModel(string id);

        IEnumerable<UserViewModel> GetAllSchoolUsers();
    }
}
