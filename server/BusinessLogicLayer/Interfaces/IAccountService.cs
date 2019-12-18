using System.Threading.Tasks;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels;
using SchoolBook.DataAccessLayer.Entities;

namespace SchoolBook.BusinessLogicLayer.Interfaces
{
    public interface IAccountService
    {
        Task<LoginViewModel> LogIn(LoginInputModel loginInputModel);
        
        Task<RegisterViewModel> Register(RegisterInputModel registerInputModel);
        
        Task SeedAdmin(RegisterInputModel model);

        Task Logout();
    }
}
