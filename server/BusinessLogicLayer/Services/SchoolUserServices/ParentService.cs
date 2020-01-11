using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels.SchoolUsers.Parent;
using SchoolBook.BusinessLogicLayer.Interfaces.SchoolUserServices;
using SchoolBook.DataAccessLayer.Interfaces;

namespace SchoolBook.BusinessLogicLayer.Services.SchoolUserServices
{
    public class ParentService : BaseService, IParentService
    {
        public ParentService(
            IRepositories repositories, 
            ILogger<BaseService> logger, 
            IMapper mapper
            ) : base(repositories, logger, mapper)
        {
        }

        public IEnumerable<ParentTableViewModel> GetAllParentsFromSchool(string schoolId)
        {
            var parents = Repositories.Parents.Query()
                .AsNoTracking()
                .Include(p => p.Children)
                .Where(p => p.School.Id == schoolId)
                .ProjectTo<ParentTableViewModel>(Mapper.ConfigurationProvider)
                .ToList();

            return parents;
        }
    }
}