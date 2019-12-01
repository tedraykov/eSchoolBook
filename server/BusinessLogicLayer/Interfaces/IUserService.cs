using System.Threading.Tasks;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels;
using SchoolBook.DataAccessLayer.Entities;

namespace SchoolBook.BusinessLogicLayer.Interfaces
{
    public interface IUserService
    {
        Task<LoginViewModel> LogIn(LoginInputModel loginInputModel);
        
        Task<RegisterViewModel> Register(RegisterInputModel registerInputModel);

        Task Logout();
    }
}
