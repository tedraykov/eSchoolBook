using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
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
    public class SubjectService : BaseService, ISubjectService
    {
        public SubjectService(
            IRepositories repositories, 
            UserManager<User> userManager, 
            ILogger<BaseService> logger, 
            IMapper mapper) : base(repositories, userManager, logger, mapper)
        {
        }

        public List<SubjectViewModel> GetAll()
        {
            var subjects = this.Repositories.Subjects.Query()
                .Include(s => s.Classes)
                .Include(s => s.Teachers)
                .OrderBy(s => s.Name)
                .ProjectTo<SubjectViewModel>(this.Mapper.ConfigurationProvider)
                .ToList();

            if (!subjects.Any())
            {
                throw new TargetException("No subjects found");
            }
            
            return subjects;
        }

        public List<SubjectViewModel> GetAllByGradeYear(int grade)
        {
            var subjects = this.Repositories.Subjects.Query()
                .Include(s => s.Classes)
                .Include(s => s.Teachers)
                .Where(s => s.GradeYear == grade)
                .OrderBy(s => s.Name)
                .ProjectTo<SubjectViewModel>(this.Mapper.ConfigurationProvider)
                .ToList();

            if (!subjects.Any())
            {
                throw new TargetException("No subjects found");
            }

            return subjects;
        }

        public SubjectViewModel GetOneById(string id)
        {
            var subject = this.Repositories.Subjects.Query()
                .Include(s => s.Classes)
                .Include(s => s.Teachers)
                .ProjectTo<SubjectViewModel>(this.Mapper.ConfigurationProvider)
                .FirstOrDefault(s => s.Id == id);
            
            if (subject is null)
            {
                throw new TargetException("Subject not found");
            }
            
            return subject;
        }

        public SubjectViewModel GetOneBySignature(string signature)
        {
            var subject = this.Repositories.Subjects.Query()
                .Include(s => s.Classes)
                .Include(s => s.Teachers)
                .ProjectTo<SubjectViewModel>(this.Mapper.ConfigurationProvider)
                .FirstOrDefault(s => s.Signature == signature);
            
            if (subject is null)
            {
                throw new TargetException("Subject not found");
            }
            
            return subject;
        }

        public void AddSubject(SubjectInputModel inputModel)
        {
            var subject = Mapper.Map<SubjectInputModel, Subject>(inputModel);
            Repositories.Subjects.Create(subject);
        }

        public SubjectViewModel EditSubject(string id, SubjectInputModel inputModel)
        {
            var subjectFromDb = Repositories.Subjects.GetWithoutTracking()
                .Find(s => s.Id == id);
            
            if (subjectFromDb is null)
            {
                throw new TargetException("Subject not found");
            }
            
            var subject = Mapper.Map<SubjectInputModel, Subject>(inputModel);
            subject.Id = subjectFromDb.Id;
            
            Repositories.Subjects.Update(subject);

            return Mapper.Map<Subject, SubjectViewModel>(subject);
        }

        public void AddTeacherToSubject(string subjectId, string teacherId)
        {
            var subject = Repositories.Subjects.GetById(subjectId);
            
            if (subject is null)
            {
                throw new TargetException("Subject isn't in our system.");
            }

            var teacher = Repositories.Teachers.GetById(teacherId);
            teacher.Subjects.Add(new TeacherToSubject
            {
                Teacher = teacher,
                TeacherId = teacherId,
                Subject = subject,
                SubjectId = subjectId
            });
            
            Repositories.Teachers.SaveChanges();
        }
        
        public void RemoveTeacherFromSubject (string subjectId, string teacherId)
        {
            var subject = this.Repositories.Subjects.Query()
                .Include(s => s.Classes)
                .Include(s => s.Teachers)
                .FirstOrDefault(s => s.Id == subjectId);
            
            if (subject is null)
            {
                throw new TargetException("Subject isn't in our system.");
            }

            var teacher = subject.Teachers.FirstOrDefault(t => t.TeacherId == teacherId);
//            teacher.Subjects.Remove(toBeDeleted);
            subject.Teachers.Remove(teacher);
            
            Repositories.Subjects.SaveChanges();
        }

        public void DeleteSubject(string id)
        {
            var subject = Repositories.Subjects.GetById(id);

            if (subject is null)
            {
                throw new TargetException("Subject isn't in our system.");
            }
            
            Repositories.Subjects.Delete(subject);
            Repositories.Subjects.SaveChanges();
        }
    }
}