using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels.SchoolUsers;
using SchoolBook.BusinessLogicLayer.Interfaces.SchoolUserServices;
using SchoolBook.DataAccessLayer.Entities;
using SchoolBook.DataAccessLayer.Entities.SchoolUserEntities;
using SchoolBook.DataAccessLayer.Interfaces;

namespace SchoolBook.BusinessLogicLayer.Services.SchoolUserServices
{
    public class StudentService : BaseService, IStudentService
    {
        private readonly IRepositories _repositories;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<BaseService> _logger;
        private readonly IMapper _mapper;

        public StudentService(
            IRepositories repositories,
            UserManager<User> userManager,
            ILogger<BaseService> logger,
            IMapper mapper) : base(repositories, userManager, logger, mapper)
        {
            _repositories = repositories;
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
        }

        public string AddStudent(StudentInputModel studentModel)
        {
            var student = _mapper.Map<StudentInputModel, Student>(studentModel);
            var studentSchool =
                _repositories.Schools.GetById(studentModel.SchoolId);
            if (studentSchool == null)
            {
                throw new TargetException("School does not exist");
            }

            var studentClass =
                _repositories.Classes.GetById(studentModel.ClassId);
            if (studentClass == null)
            {
                throw new TargetException("Class does not exist");
            }

            student.Class = studentClass;
            student.School = studentSchool;
            _repositories.Students.Create(student);
            return student.Id;
        }

        public void UpdateStudent(string studentId, StudentInputModel studentModel)
        {
            var student = _repositories.Students.GetById(studentId);
            if (student == null)
            {
                throw new TargetException("Student does not exist");
            }

            _mapper.Map(studentModel, student);
            _repositories.Students.SaveChanges();
        }

        public StudentInputModel GetStudent(string id)
        {
            var student = _repositories.Students.Query()
                .Include(o => o.School)
                .Include(o => o.Class)
                .SingleOrDefault(o => o.Id == id);
            return _mapper.Map<Student, StudentInputModel>(student);
        }

        public IEnumerable<StudentInputModel> GetAllStudents()
        {
            var students = _repositories.Students.Query()
                .Include(o => o.School)
                .Include(o => o.Class)
                .Take(10);
            return _mapper
                .Map<IEnumerable<Student>, IEnumerable<StudentInputModel>>(
                    students);
        }
    }
}
