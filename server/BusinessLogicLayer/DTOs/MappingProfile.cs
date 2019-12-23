using System.Linq;
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
                .ForMember(o => o.FullName, ex => ex.MapFrom(o => GetFullName(o)))
                .ForMember(o => o.SchoolUserId, ex => ex.MapFrom(o => o.Id));

            CreateMap<SchoolUser, SchoolUserModel>();

            CreateMap<RegisterInputModel, User>()
                .ForMember(o => o.UserName, ex => ex.MapFrom(o => o.Email));
            
            CreateMap<User, RegisterViewModel>()
                .ForMember(o => o.Id, ex => ex.MapFrom(o => o.Id));

            CreateMap<Class, ClassViewModel>();
            CreateMap<ClassInputModel, Class>();

            CreateMap<Subject, SubjectViewModel>()
                .ForMember(o => o.Teachers, ex => 
                    ex.UseDestinationValue());
            CreateMap<SubjectInputModel, Subject>();

            CreateMap<TeacherToSubject, MinimalSchoolUserModel>()
                .ForMember( o => o.Id, ex => 
                    ex.MapFrom(o => o.TeacherId))
                .ForMember( o => o.FirstName, ex => 
                    ex.MapFrom(o => o.Teacher.FirstName))
                .ForMember( o => o.SecondName, ex => 
                    ex.MapFrom(o => o.Teacher.SecondName))
                .ForMember( o => o.LastName, ex => 
                    ex.MapFrom(o => o.Teacher.LastName));
//            CreateMap<TeacherToSubject, Subject>();

            CreateMap<ClassToSubjectInputModel, ClassToSubject>();
            CreateMap<ClassToSubject, ClassToSubjectViewModel>();
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
