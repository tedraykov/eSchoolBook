using System.Linq;
using AutoMapper;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels.SchoolUsers;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels.SchoolUsers.Edit;
using SchoolBook.BusinessLogicLayer.DTOs.Models.SchoolUserModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels.SchoolUsers;
using SchoolBook.DataAccessLayer.Entities;
using SchoolBook.DataAccessLayer.Entities.SchoolUserEntities;

namespace SchoolBook.BusinessLogicLayer.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            /* -------------------- School users Mapping -------------------- */
            CreateMap<SchoolUser, UserViewModel>()
                .ForMember(o => o.Role,
                    ex => ex.MapFrom(o => o.Role))
                .ForMember(o => o.FullName,
                    ex => ex.MapFrom(o => GetFullName(o)))
                .ForMember(o => o.SchoolUserId,
                    ex => ex.MapFrom(o => o.Id));

            CreateMap<StudentModel, Student>();
            CreateMap<Student, StudentModel>()
                .ForMember(o => o.ClassId, ex => ex.MapFrom(o => o.Class.Id))
                .ForMember(o => o.UserId, ex => ex.MapFrom(o => o.User.Id));
            CreateMap<StudentEditInputModel, Student>();
            CreateMap<Student, StudentViewModel>()
                .ForMember(o => o.FullName,
                    ex => ex.MapFrom(o => GetFullName(o)))
                .ForMember(o => o.SchoolUserId,
                    ex => ex.MapFrom(o => o.Id))
                .ForMember(o => o.ClassId,
                    ex => ex.MapFrom(o => o.Class.Id));


            /* ------------------- Authentication Mapping ------------------- */
            CreateMap<RegisterInputModel, User>()
                .ForMember(o => o.UserName,
                    ex => ex.MapFrom(o => o.Email));
            

            CreateMap<User, RegisterViewModel>()
                .ForMember(o => o.Id,
                    ex => ex.MapFrom(o => o.Id));

            CreateMap<Class, ClassViewModel>();
            CreateMap<ClassInputModel, Class>();
            CreateMap<ClassToSubject, Class>()
                .ForMember(o => o.Id, ex => ex.MapFrom(o => o.Class.Id))
                .ForMember(o => o.Grade, ex => ex.MapFrom(o => o.Class.Grade))
                .ForMember(o => o.GradeLetter, ex => ex.MapFrom(o => o.Class.GradeLetter))
                .ForMember(o => o.ClassTeacher, ex => ex.MapFrom(o => o.Class.ClassTeacher))
                .ForMember(o => o.StartYear, ex => ex.MapFrom(o => o.Class.StartYear))
                .ForMember(o => o.Subjects, ex => ex.MapFrom(o => o.Class.Subjects));
            ;

            CreateMap<Subject, SubjectViewModel>()
                .ForMember(o => o.Teachers, ex =>
                    ex.UseDestinationValue());
            CreateMap<SubjectInputModel, Subject>();
            CreateMap<Subject, SubjectOnlyViewModel>();
            CreateMap<ClassToSubject, SubjectOnlyViewModel>()
                .ForMember(o => o.Grade, ex => 
                    ex.MapFrom(o => o.Class.Grade.ToString() + o.Class.GradeLetter));

            CreateMap<TeacherToSubject, MinimalSchoolUserModel>()
                .ForMember(o => o.Id, ex =>
                    ex.MapFrom(o => o.TeacherId))
                .ForMember(o => o.FirstName, ex =>
                    ex.MapFrom(o => o.Teacher.FirstName))
                .ForMember(o => o.SecondName, ex =>
                    ex.MapFrom(o => o.Teacher.SecondName))
                .ForMember(o => o.LastName, ex =>
                    ex.MapFrom(o => o.Teacher.LastName));

            CreateMap<ClassToSubjectInputModel, ClassToSubject>();
            CreateMap<ClassToSubject, ClassToSubjectViewModel>();

            CreateMap<SchoolInputModel, School>();
            CreateMap<School, SchoolViewModel>();
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
