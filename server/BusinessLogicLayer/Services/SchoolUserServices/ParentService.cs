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
    public class ParentService : BaseService, IParentService
    {
        private readonly IAccountService _accountService;
        public ParentService(
            IAccountService accountService,
            IRepositories repositories,
            ILogger<BaseService> logger,
            IMapper mapper) : base(repositories, logger, mapper)
        {
            _accountService = accountService;
        }

        public async Task AddParent(ParentModel parentModel)
        {
            var parent = Mapper.Map<ParentModel, Parent>(parentModel);
            var school = Repositories.Schools.GetById(parentModel.SchoolId);
            if (school == null)
            {
                throw new TargetException("School not found");
            }
            parent.School = school;

            foreach (var childId in parentModel.ChildrenId)
            {
                var child = Repositories.Students.GetById(childId);
                if (child == null)
                {
                    throw new TargetException("Student not found");
                }
                parent.Children.Add(child);
            }

            var account = await _accountService.RegisterSchoolUser(parent);
            if (account == null)
            {
                return;
            }
            parent.User = account;
            parent.Id = account.Id;
            Repositories.Parents.Create(parent);
        }
    }
}
