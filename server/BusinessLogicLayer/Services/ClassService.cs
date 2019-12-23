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
using SchoolBook.BusinessLogicLayer.DTOs.InputModels.SchoolUsers;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels;
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

        public  void AddClassTeacher(string classId, string teacherId)
        {
            var dbClass = this.Repositories.Classes.GetById(classId);
            
            if (dbClass is null)
            {
                throw new TargetException("Class not found");
            }

            var teacher = Repositories.Teachers.GetById(teacherId);
            
            if (teacher is null)
            {
                throw new TargetException("Teacher not found");
            }
            
            dbClass.ClassTeacher = teacher;

            this.Repositories.Classes.Update(dbClass);
        }

        public void AddSubject(string classId, ClassToSubjectInputModel inputModel)
        {
            var dbClass = this.Repositories.Classes.Query()
                .Include(c => c.Subjects)
                .FirstOrDefault(c => c.Id == classId);
            
            if (dbClass is null)
            {
                throw new TargetException("Class not found");
            }

            var subject = Repositories.Subjects.GetById(inputModel.SubjectId);

            if (subject is null)
            {
                throw new TargetException("Subject not found");
            }
            
            dbClass.Subjects.Add(new ClassToSubject
            {
                Class = dbClass,
                ClassId = classId,
                Subject = subject,
                SubjectId = subject.Id,
                EndTime = inputModel.EndTime,
                StartTime = inputModel.StartTime,
                WeekDay = inputModel.WeekDay
                
            });

            Repositories.Classes.SaveChanges();
        }

        public void EditSubject(string classId, ClassToSubjectInputModel inputModel)
        {
            var subject = Repositories.ClassToSubject.Query()
                .Include(cs => cs.Class)
                .Include(cs => cs.Subject)
                .AsNoTracking()
                .ProjectTo<ClassToSubjectViewModel>(this.Mapper.ConfigurationProvider)
                .FirstOrDefault(cs => cs.ClassId == classId);
            
            if (subject is null)
            {
                throw new TargetException("Data not found");
            }

            var newData = Mapper.Map<ClassToSubjectInputModel, ClassToSubject>(inputModel);
            newData.ClassId = classId;
            
            Repositories.ClassToSubject.Update(newData);
        }

        public void RemoveSubject(string classId, string subjectId)
        {
            var dbClass = this.Repositories.Classes.Query()
                .Include(c => c.Subjects)
                .FirstOrDefault(c => c.Id == classId);
            
            if (dbClass is null)
            {
                throw new TargetException("Class not found");
            }

            var subject = dbClass.Subjects.FirstOrDefault(s => s.SubjectId == subjectId);

            if (subject is null)
            {
                throw new TargetException("Subject not found");
            }

            dbClass.Subjects.Remove(subject);
            Repositories.Classes.SaveChanges();

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