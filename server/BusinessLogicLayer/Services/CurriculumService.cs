using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels.SchoolUsers;
using SchoolBook.BusinessLogicLayer.Interfaces;
using SchoolBook.DataAccessLayer.Interfaces;

namespace SchoolBook.BusinessLogicLayer.Services
{
    public class CurriculumService : BaseService, ICurriculumService
    {
        public CurriculumService(
            IRepositories repositories, 
            ILogger<BaseService> logger, 
            IMapper mapper) : base(repositories, logger, mapper)
        {
        }

        public List<T_ClassToSubjectViewModel> GetTeacherActiveSubjects(string teacherId)
        {
            var classToSubjects = this.Repositories.ClassToSubject.Query()
                .Include(cts => cts.Class)
                .Include(cts => cts.Subject)
                .Include(cts => cts.Teacher)
                .Where(cts => cts.Teacher.Id == teacherId)
                .ProjectTo<T_ClassToSubjectViewModel>(Mapper.ConfigurationProvider)
                .ToList();
            
            if (classToSubjects is null)
            {
                throw new TargetException("Couldn't find any data for subjects by this teacher.");
            }    

            return classToSubjects;
        }

        public List<StudentViewModel> GetStudentsInClassAttendingSubject(string classCurriculumId)
        {
            var classToSubject = this.Repositories.ClassToSubject.Query()
                .FirstOrDefault(cts => cts.Id == classCurriculumId);

            var students = this.Repositories.Students.Query()
                .Include(s => s.Class)
                .Where(s => s.Class.Id == classToSubject.ClassId)
                .ProjectTo<StudentViewModel>(Mapper.ConfigurationProvider)
                .ToList();
            
            if (students is null || !students.Any())
            {
                throw new TargetException("Couldn't find any data for students in this class.");
            }

            return students;
        }

        public List<S_ClassToSubjectViewModel> GetStudentWeeklyCurriculum(string studentId)
        {
            var student = this.Repositories.Students.Query()
                .Include(s => s.Class)
                .FirstOrDefault(s => s.Id == studentId);

            var curriculum = this.Repositories.ClassToSubject.Query()
                .Include(cts => cts.Subject)
                .Include(cts => cts.Teacher)
                .Where(cts => cts.ClassId == student.Class.Id)
                .ProjectTo<S_ClassToSubjectViewModel>(Mapper.ConfigurationProvider)
                .ToList();
            
            if (student is null || !curriculum.Any() || curriculum is null)
            {
                throw new TargetException("Couldn't find any data for student's curriculum");
            }

            return curriculum;
        }
    }
}