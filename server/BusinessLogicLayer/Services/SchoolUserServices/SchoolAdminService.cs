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
    public class SchoolAdminService : BaseService, ISchoolAdminService
    {
        private readonly IAccountService _accountService;

        public SchoolAdminService(
            IAccountService accountService,
            IRepositories repositories,
            ILogger<BaseService> logger,
            IMapper mapper) : base(repositories, logger, mapper)
        {
            _accountService = accountService;
        }

        public async Task AddSchoolAdmin(SchoolAdminModel schoolAdminModel)
        {
            var admin = Mapper.Map<SchoolAdminModel, SchoolAdmin>(schoolAdminModel);
            var school = Repositories.Schools.GetById(schoolAdminModel.SchoolId);

            if (school == null) {
                throw new TargetException("School not found");
            }

            admin.School = school;
            
            var account = await _accountService.RegisterSchoolUser(admin);
            if (account == null) {
                return;
            }
            admin.User = account;
            admin.Id = account.Id; 
            Repositories.SchoolAdmins.Create(admin);
        }
    }
}