using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using AutoMapper;
using SchoolBook.BusinessLogicLayer.DTOs.Enums;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels;
using SchoolBook.BusinessLogicLayer.DTOs.Models.SchoolUserModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels;
using SchoolBook.BusinessLogicLayer.Interfaces;
using SchoolBook.DataAccessLayer.Entities.SchoolUserEntities;
using SchoolBook.DataAccessLayer.Interfaces;

namespace SchoolBook.BusinessLogicLayer.Services
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

        public SchoolUserModel GetSchoolUserBaseModel(string id)
        {
            var user = _repositories.SchoolUsers.Query()
                .SingleOrDefault(x => x.Id == id);
            return _mapper.Map<SchoolUser, SchoolUserModel>(user);
        }

        public IEnumerable<UserViewModel> GetAllSchoolUsers()
        {
            var users = _repositories.SchoolUsers.Query();
            return _mapper
                .Map<IEnumerable<SchoolUser>, IEnumerable<UserViewModel>
                >(users);
        }

        public string AddSchoolUser(AddSchoolUserInputModel schoolUserModel)
        {
            return schoolUserModel.Role switch
            {
                RoleTypes.Student => AddStudent(schoolUserModel),
                RoleTypes.Teacher => AddTeacher(schoolUserModel),
                _ => throw new TargetException("Unsupported Student user role")
            };
        }

        /*========================= Private methods =========================*/
        private string AddStudent(AddSchoolUserInputModel schoolUserModel)
        {
            var studentModel =
                schoolUserModel.RoleSpecificModel.ToObject<StudentModel>();

            if (studentModel == null)
            {
                throw new ConstraintException(
                    "Role Specific Model is incorrect");
            }

            var student =
                _mapper.Map<SchoolUserModel, Student>(schoolUserModel
                    .BaseUserModel);
            _mapper.Map(
                studentModel,
                student);
            var studentClass =
                _repositories.Classes.GetById(studentModel.ClassId);
            student.Class = studentClass;
            _repositories.Students.Create(student);
            return student.Id;
        }

        private string AddTeacher(AddSchoolUserInputModel schoolUserModel)
        {
            var teacher =
                _mapper.Map<SchoolUserModel, Teacher>(schoolUserModel
                    .BaseUserModel);
            _repositories.Teachers.Create(teacher);
            return teacher.Id;
        }

        public void UpdateBaseSchoolUser(SchoolUserModel schoolUserModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
