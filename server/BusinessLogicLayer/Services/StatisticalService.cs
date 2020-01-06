using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using SchoolBook.BusinessLogicLayer.Interfaces;
using SchoolBook.DataAccessLayer.Entities;
using SchoolBook.DataAccessLayer.Entities.SchoolUserEntities;
using SchoolBook.DataAccessLayer.Interfaces;

namespace SchoolBook.BusinessLogicLayer.Services
{
    public class StatisticalService: BaseService, IStatisticalService
    {
        public StatisticalService(
            IRepositories repositories, 
            ILogger<BaseService> logger, 
            IMapper mapper) : base(repositories, logger, mapper)
        {
        }
        /*For Specific School*/
        public int SchoolAverageScore(string schoolId)
        {
            var students = Repositories.Students.Query()
                .Include(s => s.School)
                .Where(s => s.School.Id == schoolId)
                .ToList();
            
            var grades = new List<int>();

            foreach (var student in students)
            {
                var g = Repositories.StudentsToGrades.Query()
                    .Include(stg => stg.Grade)
                    .Where(stg => stg.StudentId == student.Id)
                    .ProjectTo<int>(Mapper.ConfigurationProvider)
                    .ToList();

                grades.AddRange(g);
            }

            var gradesSum = grades.Sum();

            return gradesSum / grades.Count;
        }

        public IDictionary<string, double> AverageSubjectScores(string schoolId)
        {
            var subjectScores = new Dictionary<string,double>();

            var subjects = Repositories.ClassToSubject.Query()
                .Include(cts => cts.Subject)
                .Include(cts => cts.Teacher)
                .ThenInclude(t => t.School)
                .Where(cts => cts.Teacher.School.Id == schoolId)
                .ProjectTo<Subject>(Mapper.ConfigurationProvider)
                .Distinct()
                .ToList();
            
            if (!subjects.Any())
            {
                throw new TargetException("No data found for subject scores");
            }

            foreach (var s in subjects)
            {
                var grades = Repositories.StudentsToGrades.Query()
                    .Include(stg => stg.Grade)
                    .Where(stg => stg.SubjectId == s.Id)
                    .ProjectTo<double>(Mapper.ConfigurationProvider)
                    .ToList();

                var avg = grades.Sum()/grades.Count();
                
                subjectScores.Add(s.Name, avg);
            }

            return subjectScores;
        }

        public IDictionary<string, double> AverageTeacherScores(string schoolId)
        {
            var teacherScores = new Dictionary<string,double>();

            var teachers = Repositories.StudentsToGrades.Query()
                .Include(stg => stg.Teacher)
                .ThenInclude(t => t.School)
                .Where(stg => stg.Teacher.School.Id == schoolId)
                .ProjectTo<Teacher>(Mapper.ConfigurationProvider)
                .Distinct()
                .ToList();
            
            if (!teachers.Any())
            {
                throw new TargetException("No data found for teacher scores");
            }

            foreach (var t in teachers)
            {
                var grades = Repositories.StudentsToGrades.Query()
                    .Include(stg => stg.Grade)
                    .Include(stg => stg.Teacher)
                    .Where(stg => stg.Teacher.Id == t.Id)
                    .ProjectTo<double>(Mapper.ConfigurationProvider)
                    .ToList();

                var avg = grades.Sum()/grades.Count();
                var tName = t.FirstName.ToString() + " " +
                            t.SecondName.Substring(0, 1) + ". " +
                            t.LastName;
                
                teacherScores.Add(tName, avg);
            }

            return teacherScores;
        }

        public IDictionary<string, int> SchoolAbsences(string schoolId)
        {
            var absencesDictionary = new Dictionary<string,int>(3);

            var absences = Repositories.Absences.Query()
                .Include(a => a.Student)
                .ThenInclude(s => s.School)
                .Where(a => a.Student.School.Id == schoolId)
                .ToList();
            
            if (!absences.Any())
            {
                throw new TargetException("No data found for school's absences");
            }
            
            absencesDictionary.Add("Excused Full Absences", absences.Count(a => a.IsExcused && a.IsFullAbsence));
            absencesDictionary.Add("Unexcused Full Absences", absences.Count(a => !a.IsExcused && a.IsFullAbsence));
            absencesDictionary.Add("Unexcused Half Absences", absences.Count(a => !a.IsExcused && !a.IsFullAbsence));

            return absencesDictionary;
        }

        /*For All Schools in DB*/
        public int SchoolAverageScore()
        {
            var grades = Repositories.StudentsToGrades.Query()
                .AsNoTracking()
                .Include(stg => stg.Grade)
                .ProjectTo<int>(Mapper.ConfigurationProvider)
                .ToList();

            return grades.Sum() / grades.Count;
        }

        public IDictionary<string, double> BestNSchools(int n)
        {
            var grades = Repositories.StudentsToGrades.Query()
                .AsNoTracking()
                .Include(stg => stg.Grade)
                .GroupBy(stg => stg.Student.School);
            
//           grades.
            return new Dictionary<string, double>();
        }

        public IDictionary<string, double> AverageSubjectScores()
        {
            var subjectScores = new Dictionary<string,double>();
            
            var subjects = Repositories.StudentsToGrades.Query()
                .AsNoTracking()
                .Include(stg => stg.Subject)
                .ProjectTo<Subject>(Mapper.ConfigurationProvider)
                .Distinct()
                .ToList();

            foreach (var s in subjects)
            {
                var grades = Repositories.StudentsToGrades.Query()
                    .AsNoTracking()
                    .Include(stg => stg.Grade)
                    .Where(stg => stg.SubjectId == s.Id)
                    .ProjectTo<double>(Mapper.ConfigurationProvider)
                    .ToList();

                subjectScores.Add(s.Name, grades.Sum()/grades.Count);
            }

            return subjectScores;
        }

        public IDictionary<string, double> AverageTeacherScores()
        {
            var teacherScores = new Dictionary<string,double>();
            
            var teachers = Repositories.StudentsToGrades.Query()
                .AsNoTracking()
                .Include(stg => stg.Teacher)
                .OrderBy(stg => stg.Teacher.School.Id)
                .ProjectTo<Teacher>(Mapper.ConfigurationProvider)
                .Distinct()
                .ToList();

            foreach (var t in teachers)
            {
                var grades = Repositories.StudentsToGrades.Query()
                    .AsNoTracking()
                    .Include(stg => stg.Grade)
                    .Where(stg => stg.Teacher.Id == t.Id)
                    .ProjectTo<double>(Mapper.ConfigurationProvider)
                    .ToList();

                var tName = t.FirstName.ToString() + " " +
                            t.SecondName.Substring(0, 1) + ". " +
                            t.LastName;
                
                teacherScores.Add(tName, grades.Sum()/grades.Count);
            }

            return teacherScores;
        }

        public IDictionary<string, int> SchoolAbsences()
        {
            throw new System.NotImplementedException();
        }
        
    }
}