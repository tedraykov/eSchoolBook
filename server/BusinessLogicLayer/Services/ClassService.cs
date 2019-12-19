using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels.SchoolUsers;
using SchoolBook.BusinessLogicLayer.Interfaces;
using SchoolBook.DataAccessLayer.Entities;
using SchoolBook.DataAccessLayer.Entities.SchoolUserEntities;
using SchoolBook.DataAccessLayer.Interfaces;

namespace SchoolBook.BusinessLogicLayer.Services
{
    public class ClassService : BaseService, IClassService
    {
        public ClassService(
            IRepositories repositories, 
            UserManager<User> userManager,
            ILogger<BaseService> logger,
            IMapper mapper
            ) : base(repositories, userManager, logger, mapper)
        {
            
        }

        public List<ClassViewModel> GetAll()
        {
            var classes = this.Repositories.Classes.Query()
                .Include(c => c.ClassTeacher)
                .Include(c => c.Subjects)
                .OrderBy(c => c.Grade)
                .ThenBy(c => c.GradeLetter)
                .ProjectTo<ClassViewModel>(this.Mapper.ConfigurationProvider)
                .ToList();

            if (!classes.Any())
            {
                throw new TargetException("No classes found");
            }

            return classes;
        }

        public List<ClassViewModel> GetAllByGrade(int grade)
        {
            var classes = this.Repositories.Classes.Query()
                .Include(c => c.ClassTeacher)
                .Include(c => c.Subjects)
                .Where( c => c.Grade == grade)
                .OrderBy(c => c.GradeLetter)
                .ProjectTo<ClassViewModel>(this.Mapper.ConfigurationProvider)
                .ToList();
            
            if (!classes.Any())
            {
                throw new TargetException("No classes found");
            }

            return classes;
        }

        public  ClassViewModel GetOne(string id)
        {
            var dbClass = this.Repositories.Classes.GetById(id);
            
            if (dbClass is null)
            {
                throw new TargetException("Class not found");
            }
            
            var dtoClass =  Mapper.Map<Class, ClassViewModel>(dbClass);
            
            return dtoClass;
        }

        public void AddClass(ClassInputModel inputModel)
        {
            var entityClass = Mapper.Map<ClassInputModel, Class>(inputModel);

            this.Repositories.Classes.Create(entityClass);
        }

        public  void AddClassTeacher(string id, TeacherInputModel teacherModel)
        {
            var dbClass = this.Repositories.Classes.GetById(id);
            
            if (dbClass is null)
            {
                throw new TargetException("Class not found");
            }
            
            var teacher = Mapper.Map<TeacherInputModel, Teacher>(teacherModel);
            dbClass.ClassTeacher = teacher;

            this.Repositories.Classes.Update(dbClass);
        }

        public ClassViewModel EditClass(string id, ClassInputModel inputModel)
        {
            var classFromDto = Repositories.Classes.GetWithoutTracking()
                .Find(c => c.Id == id);
            
            if (classFromDto is null)
            {
                throw new TargetException("Class not found");
            }
            
            var entityClass = Mapper.Map<ClassInputModel, Class>(inputModel);
            entityClass.Id = classFromDto.Id;
            
            Repositories.Classes.Update(entityClass);

            return Mapper.Map<Class, ClassViewModel>(entityClass);
        }
    }
}