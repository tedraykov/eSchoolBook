using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels;
using SchoolBook.BusinessLogicLayer.Interfaces;
using SchoolBook.DataAccessLayer.Entities;
using SchoolBook.DataAccessLayer.Interfaces;

namespace SchoolBook.BusinessLogicLayer.Services
{
    public class ClassService : BaseService, IClassService
    {
        public ClassService(
            IRepositories repositories,
            ILogger<BaseService> logger,
            IMapper mapper
            ) : base(repositories, logger, mapper)
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

        public List<ClassViewModel> GetAllBySchool(string schoolId)
        {
            return Repositories.Classes.Query()
                .Include(c => c.School)
                .Include(c => c.ClassTeacher)
                .Where(c => c.School.Id == schoolId)
                .ProjectTo<ClassViewModel>(Mapper.ConfigurationProvider)
                .ToList();
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

        public List<MinimalClassViewModel> GetClassesWithoutClassTeacher(string schoolId)
        {
            return Repositories.Classes.Query()
                .Include(c => c.School)
                .Include(c => c.ClassTeacher)
                .Where(c => c.School.Id == schoolId && c.ClassTeacher == null)
                .ProjectTo<MinimalClassViewModel>(Mapper.ConfigurationProvider)
                .ToList();
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
            
            entityClass.SchoolId = Repositories.Schools.Query()
                .AsNoTracking()
                .FirstOrDefault(s => s.Id == inputModel.SchoolId)?.Id;

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

            var teacher = Repositories.TeacherToSubject.Query()
                .Include(tts => tts.Teacher)
                .Include(tts => tts.Subject)
                .Where(tts => tts.SubjectId == inputModel.SubjectId)
                .FirstOrDefault(tts => tts.TeacherId == inputModel.TeacherId);
            
            if (teacher is null)
            {
                throw new TargetException("Teacher not found");
            }
            
            dbClass.Subjects.Add(new ClassToSubject
            {
                Id = Guid.NewGuid().ToString(),
                Class = dbClass,
                ClassId = classId,
                Subject = subject,
                SubjectId = subject.Id,
                Teacher = teacher.Teacher,
                EndTime = inputModel.EndTime,
                StartTime = inputModel.StartTime,
                WeekDay = inputModel.WeekDay
                
            });

            Repositories.Classes.SaveChanges();
        }

        public void EditSubject(string classId, ClassToSubjectInputModel inputModel)
        {
            var subject = Repositories.ClassToSubject.Query()
                .Include(cs => cs.Subject)
                .Include(cs => cs.Teacher)
                .AsNoTracking()
                .Where(cs => cs.ClassId == classId)
                .FirstOrDefault(cs => cs.SubjectId == inputModel.SubjectId);
            
            if (subject is null)
            {
                throw new TargetException("Data not found");
            }

            var teacher = Repositories.TeacherToSubject.Query()
                .Include(tts => tts.Teacher)
                .Include(tts => tts.Subject)
                .Where(tts => tts.SubjectId == inputModel.SubjectId)
                .FirstOrDefault(tts => tts.TeacherId == inputModel.TeacherId);
            
            if (teacher is null)
            {
                throw new TargetException("Teacher not found");
            }

            var newData = Mapper.Map<ClassToSubjectInputModel, ClassToSubject>(inputModel);
            newData.Id = subject.Id;
            newData.ClassId = classId;
            newData.SubjectId = subject.SubjectId;
            newData.Teacher = teacher.Teacher;
            
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
