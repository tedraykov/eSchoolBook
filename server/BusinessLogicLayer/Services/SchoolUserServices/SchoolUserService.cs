using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels;
using SchoolBook.BusinessLogicLayer.Interfaces;
using SchoolBook.DataAccessLayer.Entities.SchoolUserEntities;
using SchoolBook.DataAccessLayer.Interfaces;

namespace SchoolBook.BusinessLogicLayer.Services.SchoolUserServices
{
    public class SchoolUserService : ISchoolUserService
    {
        private readonly IRepositories _repositories;
        private readonly IMapper _mapper;

        public SchoolUserService(IRepositories repositories, IMapper mapper)
        {
            _repositories = repositories;
            _mapper = mapper;
        }

        public UserViewModel GetSchoolUserBaseModel(string id)
        {
            var user = _repositories.SchoolUsers.Query()
                .SingleOrDefault(x => x.Id == id);
            return _mapper.Map<SchoolUser, UserViewModel>(user);
        }

        public IEnumerable<UserViewModel> GetAllSchoolUsers()
        {
            var users = _repositories.SchoolUsers.Query();
            return _mapper
                .Map<IEnumerable<SchoolUser>, IEnumerable<UserViewModel>
                >(users);
        }

        /*========================= Private methods =========================*/
//        private string AddStudent(AddSchoolUserInputModel schoolUserModel)
//        {
//            var studentModel =
//                schoolUserModel.RoleSpecificModel.ToObject<StudentModel>();
//
//            if (studentModel == null)
//            {
//                throw new ConstraintException(
//                    "Role Specific Model is incorrect");
//            }
//
//            var student =
//                _mapper.Map<SchoolUserModel, Student>(schoolUserModel
//                    .BaseUserModel);
//            _mapper.Map(studentModel, student);
//            var studentClass =
//                _repositories.Classes.GetById(studentModel.ClassId);
//            student.Class = studentClass;
//            var school = GetSchool(schoolUserModel.BaseUserModel.SchoolId);
//            student.School = school;
//            _repositories.Students.Create(student);
//            return student.Id;
//        }
//
//        private string AddTeacher(AddSchoolUserInputModel schoolUserModel)
//        {
//            var teacher =
//                _mapper.Map<SchoolUserModel, Teacher>(schoolUserModel
//                    .BaseUserModel);
//            var school = GetSchool(schoolUserModel.BaseUserModel.SchoolId);
//            teacher.School = school;
//            _repositories.Teachers.Create(teacher);
//            return teacher.Id;
//        }
//
//        public void UpdateBaseSchoolUser(SchoolUserModel schoolUserModel)
//        {
//            throw new NotImplementedException();
//        }
//
//        private School GetSchool(string schoolId)
//        {
//            var school =
//                _repositories.Schools.GetById(schoolId);
//            if (school == null)
//            {
//                throw new TargetException("School Id is invalid");
//            }
//
//            return school;
//        }
    }
}
