using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using SchoolBook.BusinessLogicLayer.DTOs.Enums;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels.SchoolUsers.Edit;
using SchoolBook.BusinessLogicLayer.DTOs.Models.SchoolUserModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels.SchoolUsers;
using SchoolBook.BusinessLogicLayer.Interfaces;
using SchoolBook.BusinessLogicLayer.Interfaces.SchoolUserServices;
using SchoolBook.DataAccessLayer.Entities;
using SchoolBook.DataAccessLayer.Entities.SchoolUserEntities;
using SchoolBook.DataAccessLayer.Interfaces;

namespace SchoolBook.BusinessLogicLayer.Services.SchoolUserServices
{
    public class StudentService : BaseService, IStudentService
    {
        private readonly IAccountService _accountService ;
        private readonly IStatisticalService _statisticalService ;
        public StudentService(
            IAccountService accountService,
            IStatisticalService statisticalService,
            IRepositories repositories,
            ILogger<BaseService> logger,
            IMapper mapper) : base(repositories, logger, mapper)
        {
            _accountService = accountService;
            _statisticalService = statisticalService;
        }

        public IEnumerable<StudentModel> GetAllStudents()
        {
            var students = Repositories.Students.Query()
                .Include(o => o.School)
                .Include(o => o.Class)
                .Include(o => o.User)
                .ProjectTo<StudentModel>(Mapper.ConfigurationProvider);

            return students;
        }

        public IEnumerable<StudentTableViewModel> GetAllStudentsFromSchool(string schoolId)
        {
            var students = Repositories.Students.Query()
                .Include(o => o.School)
                .Include(o => o.Class)
                .Include(o => o.User)
                .Where(s => s.School.Id == schoolId)
                .ProjectTo<StudentTableViewModel>(Mapper.ConfigurationProvider)
                .ToList();

            return students;
        }

        public IEnumerable<StudentModel> GetAllStudentsFromClass(string classId)
        {
            var students = Repositories.Students.Query()
                .Include(o => o.School)
                .Include(o => o.Class)
                .Include(o => o.User)
                .Where(s => s.Class.Id == classId)
                .ProjectTo<StudentModel>(Mapper.ConfigurationProvider);

            return students;
        }

        public StudentModel GetStudent(string id)
        {
            var student = Repositories.Students.Query()
                .Include(o => o.School)
                .Include(o => o.Class)
                .Include(o => o.User)
                .SingleOrDefault(o => o.Id == id);
            return Mapper.Map<Student, StudentModel>(student);
        }
        
        public StudentDialogViewModel GetStudentDialogData(string id)
        {
            var st = Repositories.Students.Query()
                .AsNoTracking()
                .Include(s => s.Class)
                .Include(s => s.Parent)
                .Include(s => s.User)
                .FirstOrDefault(s => s.Id == id);

            var student = Mapper.Map<Student, StudentDialogViewModel>(st);
            
            student.AvgScore = _statisticalService.StudentAverageScore(id);
            student.Absences = _statisticalService.StudentAbsences(id);

            return student;
        }

        public async Task AddStudent(StudentModel studentModel)
        {
            if (Repositories.SchoolUsers.Query().Any(su => su.Pin == studentModel.Pin))
            {
                throw new DuplicateNameException("User already exists");
            }

            var student = Mapper.Map<StudentModel, Student>(studentModel);
            var studentSchool = Repositories.Schools.GetById(studentModel.SchoolId);
            
            if (studentSchool == null)
            {
                throw new TargetException("School does not exist");
            }

            var studentClass = Repositories.Classes.GetById(studentModel.ClassId);
            
            if (studentClass == null)
            {
                throw new TargetException("Class does not exist");
            }

            student.Class = studentClass;
            student.School = studentSchool;
            
            var account =  await _accountService.RegisterSchoolUser(student);
            student.User = account;
            student.Id = student.User.Id;
            
            Repositories.Students.Create(student);
        }

        public void UpdateStudent(string studentId, StudentEditInputModel editModel)
        {
            var student = Repositories.Students.Query()
                .AsNoTracking()
                .SingleOrDefault(s => s.Id == studentId);
            if (student == null)
            {
                throw new TargetException("Student does not exist");
            }

            var newData = Mapper.Map<StudentEditInputModel, Student>(editModel);
            newData.Id = studentId;
            newData.StartYear = student.StartYear;
            
            Repositories.Students.Update(newData);
        }

        public void GradeStudent(string studentId, GradeInputModel gradeModel)
         {
             var student = Repositories.Students.GetById(studentId);
 
             var grade = Repositories.Grades.GetWithoutTracking()
                 .SingleOrDefault(g => g.Id == gradeModel.GradeId);

             var ts = Repositories.TeacherToSubject.Query()
                 .AsNoTracking()
                 .Include(tts => tts.Teacher)
                 .Include(tts => tts.Subject)
                 .SingleOrDefault(tts => tts.TeacherId == gradeModel.TeacherId
                                         && tts.SubjectId == gradeModel.SubjectId);
             
             if( ts is null ) throw  new TargetException("Invalid input data");
             
             var subject = Repositories.Subjects.GetWithoutTracking()
                 .SingleOrDefault(s => s.Id == gradeModel.SubjectId);
             
             var teacher = Repositories.Teachers.GetWithoutTracking()
                 .SingleOrDefault(t => t.Id == gradeModel.TeacherId);

             var newGrade = new StudentToGrade
             {
                 DateCreated = DateTime.Now,
                 DateModified = DateTime.Now,
                 GradeId = gradeModel.GradeId,
                 Grade = grade,
                 SubjectId = gradeModel.SubjectId,
                 Subject = subject,
                 StudentId = studentId,
                 Student = student,
                 Teacher = teacher
             };
             student.Grades.Add(newGrade);
 
             Repositories.Students.SaveChanges();
         }

        public void EditGrade(string gradeId, string newGradeId)
        {
            var grade = Repositories.StudentsToGrades.Query()
                .Include(stg => stg.Grade)
                .SingleOrDefault(stg => stg.Id == gradeId);

            if (grade is null)
            {
                throw new TargetException("Grade not found");
            }

            grade.GradeId = newGradeId;
            grade.DateModified = DateTime.Now;

            Repositories.StudentsToGrades.SaveChanges();
        }

        public void RemoveGrade(string gradeId)
        {
            var grade = Repositories.StudentsToGrades.GetById(gradeId);
            
            Repositories.StudentsToGrades.Delete(grade);
            Repositories.StudentsToGrades.SaveChanges();
        }

        public void AddAbsenceToStudent(string studentId, AbsenceInputModel absenceModel)
        {
            var student = Repositories.Students.Query()
                .SingleOrDefault(s => s.Id == studentId);

            if (student is null)
            {
                throw  new TargetException("Student not found");
            }
            
            var subject = Repositories.Subjects.GetWithoutTracking()
                .SingleOrDefault(s => s.Id == absenceModel.SubjectId);
            var teacher = Repositories.Teachers.GetWithoutTracking()
                .SingleOrDefault(t => t.Id == absenceModel.TeacherId);
            
            var absence = new Absence
            {
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                Student = student,
                Subject = subject,
                IsFullAbsence = absenceModel.IsFullAbsence,
                IsExcused = false,
                Teacher = teacher
            };
            
            student.Absences.Add(absence);

            Repositories.Students.SaveChanges();
        }

        public void ExcuseStudentAbsence(string studentId, string absenceId)
        {
            var student = Repositories.Students.Query()
                .Include(s => s.Absences)
                .SingleOrDefault(s => s.Id == studentId);
            
            if (student is null)
            {
                throw  new TargetException("Student not found");
            }
            
            var absence = student.Absences.SingleOrDefault(a => a.Id == absenceId);
            
            if (absence is null)
            {
                throw  new TargetException("Student absence not found");
            }

            if (!absence.IsFullAbsence)
            {
                throw new ArgumentException("Cannot excuse absences that aren't full.");
            }

            absence.IsExcused = true;
            absence.DateModified = DateTime.Now;

            Repositories.Students.SaveChanges();

        }

        public void RemoveStudent(string studentId)
        {
            var student = Repositories.Students.GetById(studentId);

            if (student is null)
            {
                throw new TargetException("Student not found.");
            }
            
            Repositories.Students.Delete(student);
            Repositories.Students.SaveChanges();
        }
    }
}
