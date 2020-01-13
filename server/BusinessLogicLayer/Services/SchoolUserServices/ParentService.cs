using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels.SchoolUsers;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels.SchoolUsers.Parent;
using SchoolBook.BusinessLogicLayer.Interfaces.SchoolUserServices;
using SchoolBook.DataAccessLayer.Interfaces;

namespace SchoolBook.BusinessLogicLayer.Services.SchoolUserServices
{
    public class ParentService : BaseService, IParentService
    {
        private IStudentService StudentService;
        
        public ParentService(
            IStudentService studentService,
            IRepositories repositories, 
            ILogger<BaseService> logger, 
            IMapper mapper
            ) : base(repositories, logger, mapper)
        {
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
    }
}