using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SchoolBook.BusinessLogicLayer.DTOs.Models.SchoolUserModels;
using SchoolBook.BusinessLogicLayer.Interfaces;
using SchoolBook.BusinessLogicLayer.Interfaces.SchoolUserServices;
using SchoolBook.DataAccessLayer.Entities.SchoolUserEntities;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels.SchoolUsers.Teacher;
using SchoolBook.DataAccessLayer.Interfaces;

namespace SchoolBook.BusinessLogicLayer.Services.SchoolUserServices
{
    public class TeacherService : BaseService, ITeacherService
    {
        private readonly IAccountService _accountService ;
        private readonly IStatisticalService StatisticalService;
        public TeacherService(
            IStatisticalService statisticalService,
            IAccountService accountService,
            IRepositories repositories,
            ILogger<BaseService> logger,
            IMapper mapper) : base(repositories, logger, mapper)
        {
            _accountService = accountService;
            StatisticalService = statisticalService;
        }

        public async Task AddTeacher(TeacherModel teacherModel)
        {
            var teacher = Mapper.Map<TeacherModel, Teacher>(teacherModel);
            var school = Repositories.Schools.GetById(teacherModel.SchoolId);

            if (school == null) {
                throw new TargetException("School not found");
            }
            teacher.School = school;
            
            var account = await _accountService.RegisterSchoolUser(teacher);
            if (account == null) {
                return;
            }
            teacher.User = account;
            teacher.Id = account.Id; 
            Repositories.Teachers.Create(teacher);
        }

        public IEnumerable<TeacherTableViewModel> GetAllTeachersFromSchool(string schoolId)
        {
            var teachers = Repositories.Teachers.Query()
                .AsNoTracking()
                .Include(t => t.School)
                .Where(t => t.School.Id == schoolId)
                .ProjectTo<TeacherTableViewModel>(Mapper.ConfigurationProvider)
                .ToList();

            var classes = Repositories.Classes.Query()
                .AsNoTracking()
                .Include(c => c.ClassTeacher)
                .ThenInclude(ct => ct.School)
                .Where(c => c.ClassTeacher.School.Id == schoolId)
                .ProjectTo<ClassTeacherModel>(Mapper.ConfigurationProvider)
                .ToList();

            foreach (var t in teachers)
            {
                if (classes.Any(c => c.TeacherId == t.SchoolUserId))
                {
                    t.Grade = classes.FirstOrDefault(c => c.TeacherId == t.SchoolUserId)?.Class;
                }
                else
                {
                    t.Grade = "-";
                }
            }

            return teachers;
        }

        public TeacherDialogViewModel GetTeacherDialogData(string teacherId)
        {
            var teacher = Repositories.Teachers.Query()
                .AsNoTracking()
                .Include(t => t.User)
                .Include(t => t.Subjects)
                .ThenInclude(s => s.Subject)
                .ProjectTo<TeacherDialogViewModel>(Mapper.ConfigurationProvider)
                .FirstOrDefault(t => t.SchoolUserId == teacherId);
            
            var grade = Repositories.Classes.Query()
                .AsNoTracking()
                .Include(c => c.ClassTeacher)
                .ThenInclude(ct => ct.School)
                .Where(c => c.ClassTeacher.Id == teacherId)
                .ProjectTo<string>(Mapper.ConfigurationProvider)
                .FirstOrDefault();

            if (grade is null)
            {
                teacher.Grade = "-";
            }
            
            teacher.Grade = grade;
            teacher.AvgScore = StatisticalService.TeacherAverageScore(teacherId);

            return teacher;
        }
    }
}