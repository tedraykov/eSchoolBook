using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels.SchoolUsers.Parent;
using SchoolBook.BusinessLogicLayer.Interfaces.SchoolUserServices;
using System.Reflection;
using System.Threading.Tasks;
using SchoolBook.BusinessLogicLayer.DTOs.Models.SchoolUserModels;
using SchoolBook.BusinessLogicLayer.Interfaces;
using SchoolBook.DataAccessLayer.Entities.SchoolUserEntities;
using SchoolBook.DataAccessLayer.Interfaces;

namespace SchoolBook.BusinessLogicLayer.Services.SchoolUserServices
{
    public class ParentService : BaseService, IParentService
    {
        private IStudentService StudentService;
        private readonly IAccountService _accountService;
        
        public ParentService(
            IAccountService accountService,
            IStudentService studentService,
            IRepositories repositories, 
            ILogger<BaseService> logger, 
            IMapper mapper
            ) : base(repositories, logger, mapper)
        {
            _accountService = accountService;
            StudentService = studentService;
        }

        public IEnumerable<ParentViewModel> GetAllParentsFromSchool(string schoolId)
        {
            var parents = Repositories.Parents.Query()
                .AsNoTracking()
                .Include(p => p.User)
                .Include(p => p.School)
                .Include(p => p.Children)
                .Where(p => p.School.Id == schoolId)
                .ProjectTo<ParentViewModel>(Mapper.ConfigurationProvider)
                .ToList();

            return parents;
        }

        public ParentDialogViewModel GetParentDialogData(string parentId)
        {
            var children = Repositories.Students.Query()
                .AsNoTracking()
                .Include(o => o.User)
                .Include(o => o.Parent)
                .Where(s => s.Parent.Id == parentId)
                .ToList();
         
            var parent = Repositories.Parents.Query()
                .AsNoTracking()
                .Include(p => p.Children)
                .Include(p => p.User)
                .ProjectTo<ParentDialogViewModel>(Mapper.ConfigurationProvider)
                .FirstOrDefault(p => p.SchoolUserId == parentId);

            foreach (var ch in children)
            {
                parent.ChildrenData.Add(StudentService.GetStudentDialogData(ch.Id));
            }

            return parent;
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