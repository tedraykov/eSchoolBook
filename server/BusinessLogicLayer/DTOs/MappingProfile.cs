using AutoMapper;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels;
using SchoolBook.BusinessLogicLayer.DTOs.Models.SchoolUserModels;
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
                .ForMember(o => o.Role, ex => ex.MapFrom(o => o.Role))
                .ForMember(o => o.FullName,
                    ex => ex.MapFrom(o => GetFullName(o)))
                .ForMember(o => o.SchoolUserId, ex => ex.MapFrom(o => o.Id));

            CreateMap<SchoolUser, SchoolUserModel>()
                .ForMember(o => o.SchoolId, ex => ex.MapFrom(o => o.SchoolId))
                .ReverseMap();

            CreateMap<RegisterInputModel, User>()
                .ForMember(o => o.UserName, ex => ex.MapFrom(o => o.Email));

            CreateMap<User, RegisterViewModel>()
                .ForMember(o => o.Id, ex => ex.MapFrom(o => o.Id));

            CreateMap<SchoolUserModel, Student>();
            CreateMap<SchoolUserModel, Teacher>();
            CreateMap<SchoolUserModel, Principal>();
            CreateMap<SchoolUserModel, Parent>();

            CreateMap<StudentModel, Student>()
                .ForMember(o => o.ClassId, ex => ex.MapFrom(o => o.ClassId));

            CreateMap<Class, ClassViewModel>();
            CreateMap<ClassInputModel, Class>();
        }

        private static string GetFullName(SchoolUser user)
        {
            var fullName = user.FirstName;
            if (user.SecondName != null)
            {
                fullName += ' ' + user.SecondName;
            }

            fullName += ' ' + user.LastName;
            return fullName;
        }
    }
}
