using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SchoolBook.BusinessLogicLayer.DTOs.Models.SchoolUserModels;
using SchoolBook.BusinessLogicLayer.Interfaces;
using SchoolBook.BusinessLogicLayer.Interfaces.SchoolUserServices;
using SchoolBook.DataAccessLayer.Entities.SchoolUserEntities;
using SchoolBook.DataAccessLayer.Interfaces;

namespace SchoolBook.BusinessLogicLayer.Services.SchoolUserServices
{
    public class TeacherService : BaseService, ITeacherService
    {
        private readonly IAccountService _accountService ;
        public TeacherService(
            IAccountService accountService,
            IRepositories repositories,
            ILogger<BaseService> logger,
            IMapper mapper) : base(repositories, logger, mapper)
        {
            _accountService = accountService;
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
    }
}
