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
    public class PrincipalService : BaseService, IPrincipalService
    {
        private readonly IAccountService _accountService ;
        public PrincipalService(
            IAccountService accountService,
            IRepositories repositories,
            ILogger<BaseService> logger,
            IMapper mapper) : base(repositories, logger, mapper)
        {
            _accountService = accountService;
        }

        public async Task AddPrincipal(PrincipalModel principalModel)
        {
            var principal = Mapper.Map<PrincipalModel, Principal>(principalModel);
            var school = Repositories.Schools.GetById(principalModel.SchoolId);

            if (school == null) {
                throw new TargetException("School not found");
            }
            principal.School = school;
            
            var account = await _accountService.RegisterSchoolUser(principal);
            if (account == null) {
                return;
            }
            principal.User = account;
            principal.Id = account.Id; 
            Repositories.Principals.Create(principal);
        }
    }
}
