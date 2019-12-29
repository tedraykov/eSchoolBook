using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels.SchoolUsers;
using SchoolBook.BusinessLogicLayer.Interfaces;
using SchoolBook.DataAccessLayer.Entities;
using SchoolBook.DataAccessLayer.Interfaces;

namespace SchoolBook.BusinessLogicLayer.Services
{
    public class SchoolService : BaseService, ISchoolService
    {
        public SchoolService(
            IRepositories repositories,
            ILogger<BaseService> logger, 
            IMapper mapper) : base(repositories, logger, mapper)
        {
        }

        public ICollection<SchoolViewModel> GetAll()
        {
            var schools = Repositories.Schools.Query()
                .ProjectTo<SchoolViewModel>(Mapper.ConfigurationProvider)
                .ToList();

            if (!schools.Any())
            {
                throw new TargetException("No schools found");
            }

            return schools;
        }

        public SchoolViewModel GetOneById(string schoolId)
        {
            var school = Repositories.Schools.GetById(schoolId);

            if (school is null)
            {
                throw new TargetException("School not found");
            }

            return Mapper.Map<School, SchoolViewModel>(school);
        }

        public void AddSchool(SchoolInputModel inputModel)
        {
            var school = Mapper.Map<SchoolInputModel, School>(inputModel);
            
            Repositories.Schools.Create(school);
        }

        public void EditSchool(string schoolId, SchoolInputModel inputModel)
        {
            var newData = Mapper.Map<SchoolInputModel, School>(inputModel);
            newData.Id = schoolId;
            
            Repositories.Schools.Update(newData);
        }

        public void DeleteSchool(string schoolId)
        {
            var school = Repositories.Schools.GetById(schoolId);

            if (school is null)
            {
                throw new TargetException("School not found");
            }
            
            Repositories.Schools.Delete(school);
            Repositories.Schools.SaveChanges();
        }
    }
}