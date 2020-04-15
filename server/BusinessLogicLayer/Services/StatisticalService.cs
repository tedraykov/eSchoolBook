using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using SchoolBook.BusinessLogicLayer.DTOs.Models;
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
        public double SchoolAverageScore(string schoolId)
        {
            var students = Repositories.Students.Query()
                .Include(s => s.School)
                .Where(s => s.School.Id == schoolId)
                .ToList();
            
            var grades = new List<double>();

            foreach (var student in students)
            {
                var g = Repositories.StudentsToGrades.Query()
                    .Include(stg => stg.Grade)
                    .Where(stg => stg.StudentId == student.Id)
                    .ProjectTo<double>(Mapper.ConfigurationProvider)
                    .ToList();

                grades.AddRange(g);
            }

            if (grades.Count <= 0)
            {
                throw new ArithmeticException("No grades registered for this school");
            }
            var gradesAvg = grades.Sum() / grades.Count;

            return gradesAvg ;
        }

        public ICollection<StringDoubleModel> AverageSubjectScores(string schoolId)
        {
            var subjectScores = new List<StringDoubleModel>();

            var subjects = Repositories.TeacherToSubject.Query()
                .Include(cts => cts.Subject)
                .Include(cts => cts.Teacher)
                .ThenInclude(t => t.School)
                .Where(cts => cts.Teacher.School.Id == schoolId)
                .ToList();
            
            if (!subjects.Any())
            {
                throw new TargetException("No data found for subject scores");
            }

            foreach (var s in subjects)
            {
                var grades = Repositories.StudentsToGrades.Query()
                    .Include(stg => stg.Grade)
                    .Where(stg => stg.SubjectId == s.SubjectId)
                    .ProjectTo<double>(Mapper.ConfigurationProvider)
                    .ToList();

                var avg = grades.Sum()/grades.Count();
                
                subjectScores.Add(new StringDoubleModel
                {
                    Name = s.Subject.Name + " (" 
                                          + s.Teacher.FirstName + " " + 
                                          s.Teacher.SecondName.Substring(0,1) 
                                          + ". " + s.Teacher.LastName + ")", 
                    Value = avg,
                });
            }

            return subjectScores;
        }

        public ICollection<StringDoubleModel> AverageTeacherScores(string schoolId)
        {
            var teacherScores = new List<StringDoubleModel>();

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
                
                teacherScores.Add(new StringDoubleModel { Name = tName, Value = avg});
            }

            return teacherScores;
        }

        public ICollection<StringDoubleModel> SchoolAbsences(string schoolId)
        {
            var absencesDictionary = new List<StringDoubleModel>(3);

            var absences = Repositories.Absences.Query()
                .Include(a => a.Student)
                .ThenInclude(s => s.School)
                .Where(a => a.Student.School.Id == schoolId)
                .ToList();
            
            if (!absences.Any())
            {
                throw new TargetException("No data found for school's absences");
            }
            
            absencesDictionary.Add(new StringDoubleModel{ 
                Name = "Excused Full Absences", 
                Value = absences.Count(a => a.IsExcused && a.IsFullAbsence)});
            absencesDictionary.Add(new StringDoubleModel{
                Name = "Unexcused Full Absences",
                Value = absences.Count(a => !a.IsExcused && a.IsFullAbsence)});
            absencesDictionary.Add(new StringDoubleModel {
                Name = "Unexcused Half Absences",
                Value = absences.Count(a => !a.IsExcused && !a.IsFullAbsence)
            });

            return absencesDictionary;
        }

        /*For All Schools in DB*/
        public double SchoolAverageScore()
        {
            var grades = Repositories.StudentsToGrades.Query()
                .AsNoTracking()
                .Include(stg => stg.Grade)
                .ProjectTo<int>(Mapper.ConfigurationProvider)
                .ToList();

            return grades.Sum() / grades.Count;
        }

        public ICollection BestNSchools(int n)
        {
            var schools = Repositories.Schools.Query()
                .ToList();
            
            var schoolsAvg = new Dictionary<string, double>();

            foreach (var s in schools)
            {
                var avg = SchoolAverageScore(s.Id);
                schoolsAvg.Add(s.Name, avg);
            }
            
            return schoolsAvg.OrderBy(key => key.Value).ToList().GetRange(0,n);
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

        public IDictionary<string, ICollection<StringDoubleModel>> SchoolAbsences()
        {
            var schools = Repositories.Schools.Query()
                .ToList();
            
            var schoolsAbsences = new Dictionary<string, ICollection<StringDoubleModel>>();

            foreach (var s in schools)
            {
                var avg = SchoolAbsences(s.Id);
                schoolsAbsences.Add(s.Name, avg);
            }

            return schoolsAbsences;
        }

        /*For Single user*/
        public double StudentAverageScore(string studentId)
        {
            var grades = Repositories.StudentsToGrades.Query()
                .Include(stg => stg.Grade)
                .Include(stg => stg.Subject)
                .Where(stg => stg.StudentId == studentId)
                .ProjectTo<double>(Mapper.ConfigurationProvider)
                .ToList();
            
            if (grades.Count <= 0)
            {
                throw new ArithmeticException("No grades registered for this student");
            }

            return grades.Sum() / grades.Count();
        }

        public IDictionary<string, int> StudentAbsences(string studentId)
        {
            var absencesDictionary = new Dictionary<string,int>(3);

            var absences = Repositories.Absences.Query()
                .Include(a => a.Student)
                .Where(a => a.Student.Id == studentId)
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

        public double TeacherAverageScore(string teacherId)
        {
            var grades = Repositories.StudentsToGrades.Query()
                .Include(stg => stg.Grade)
                .Include(stg => stg.Subject)
                .Include(stg => stg.Teacher)
                .Where(stg => stg.Teacher.Id == teacherId)
                .ProjectTo<double>(Mapper.ConfigurationProvider)
                .ToList();
            
            if (grades.Count <= 0)
            {
                throw new ArithmeticException("No grades registered for this teacher");
            }

            return grades.Sum() / grades.Count();
        }
    }
}