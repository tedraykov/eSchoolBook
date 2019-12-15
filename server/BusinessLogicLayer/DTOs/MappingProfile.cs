using AutoMapper;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels;
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
        }
    }
}
