using System.Threading.Tasks;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels;
using SchoolBook.DataAccessLayer.Entities;
using SchoolBook.DataAccessLayer.Entities.SchoolUserEntities;

namespace SchoolBook.BusinessLogicLayer.Interfaces
{
    public interface IAccountService
    {
        Task<LoginViewModel> LogIn(LoginInputModel loginInputModel);
        
        Task<User> Register(FullRegisterInputModel inputModel);
        
        Task SeedAdmin(RegisterInputModel model);

        Task Logout();

        Task<User> RegisterSchoolUser(SchoolUser schoolUser);
    }
}
