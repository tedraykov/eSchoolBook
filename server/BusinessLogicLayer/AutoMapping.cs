using AutoMapper;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels;
using SchoolBook.DataAccessLayer.Entities;

namespace SchoolBook.BusinessLogicLayer
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<RegisterInputModel, User>();
            CreateMap<User, RegisterViewModel>();
        }
    }
}