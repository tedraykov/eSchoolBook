using AutoMapper;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels;
using SchoolBook.DataAccessLayer.Entities;
using SchoolBook.DataAccessLayer.Entities.SchoolUserEntities;

namespace SchoolBook.BusinessLogicLayer.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SchoolUser, UserViewModel>()
                .ForMember(o => o.Role, ex => ex.MapFrom(o => o.Role));

            CreateMap<RegisterInputModel, User>()
                .ForMember(o => o.UserName, ex => ex.MapFrom(o => o.Email));
            
            CreateMap<User, RegisterViewModel>()
                .ForMember(o => o.Id, ex => ex.MapFrom(o => o.Id));
        }
    }
}
