using System;
using System.Collections.Generic;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels;
using SchoolBook.BusinessLogicLayer.DTOs.Models.SchoolUserModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels;

namespace SchoolBook.BusinessLogicLayer.Interfaces
{
    public interface ISchoolUserService
    {
        SchoolUserModel GetSchoolUserBaseModel(string id);

        IEnumerable<UserViewModel> GetAllSchoolUsers();

        string AddSchoolUser(AddSchoolUserInputModel schoolUserModel);

        void UpdateBaseSchoolUser(SchoolUserModel schoolUserModel);
    }
}
