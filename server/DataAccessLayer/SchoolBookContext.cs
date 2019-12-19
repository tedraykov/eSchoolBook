using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolBook.BusinessLogicLayer.DTOs.Enums;
using SchoolBook.DataAccessLayer.Entities;
using SchoolBook.DataAccessLayer.Entities.SchoolUserEntities;

namespace SchoolBook.DataAccessLayer
{
    public class SchoolBookContext : IdentityDbContext<User>
    {
        public SchoolBookContext(DbContextOptions<SchoolBookContext> options) : base(options)
        {
        }
        public DbSet<SchoolUser> SchoolUsers { get; set; }
        
        public DbSet<Student> Students { get; set; }

        public DbSet<Parent> Parents { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Principal> Principals { get; set; }

        public DbSet<School> Schools { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public DbSet<Absence> Absences { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Class> Classes { get; set; }

        public DbSet<ClassToSubject> ClassesToSubjects { get; set; }

        public DbSet<StudentToGrade> StudentsToGrades { get; set; }

        public DbSet<TeacherToSubject> TeachersToSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /*
             Table per hierarchy configuration for school users
             TPC not supported by EF Core. SMH 
            */

            builder.Entity<SchoolUser>()
                .Property(s => s.Role)
                .HasConversion<string>();

            builder.Entity<SchoolUser>()
                .HasDiscriminator(o => o.Role)
                .HasValue<SchoolUser>(RoleTypes.NotUser)
                .HasValue<Student>(RoleTypes.Student)
                .HasValue<Teacher>(RoleTypes.Teacher)
                .HasValue<Principal>(RoleTypes.Principal)
                .HasValue<Parent>(RoleTypes.Parent);
            
            /* Many to many relationships configuration */
            builder.Entity<ClassToSubject>()
                .HasKey(cts => new {cts.ClassId, cts.SubjectId});
            builder.Entity<ClassToSubject>()
                .HasOne(cts => cts.Class)
                .WithMany(book => book.Subjects)
                .HasForeignKey(cts => cts.ClassId);
            builder.Entity<ClassToSubject>()
                .HasOne(cts => cts.Subject)
                .WithMany(subject => subject.Classes)
                .HasForeignKey(cts => cts.SubjectId);

            builder.Entity<StudentToGrade>()
                .HasKey(
                    stg => new {stg.StudentId, stg.GradeId, stg.SubjectId});
            builder.Entity<StudentToGrade>()
                .HasOne(stg => stg.Student)
                .WithMany(student => student.Grades)
                .HasForeignKey(sta => sta.StudentId);
            builder.Entity<StudentToGrade>()
                .HasOne(stg => stg.Grade)
                .WithMany(grade => grade.Students)
                .HasForeignKey(stg => stg.GradeId);

            builder.Entity<TeacherToSubject>()
                .HasKey(tts => new {tts.SubjectId, tts.TeacherId});
            builder.Entity<TeacherToSubject>()
                .HasOne(tts => tts.Teacher)
                .WithMany(teacher => teacher.Subjects)
                .HasForeignKey(tts => tts.TeacherId);
            builder.Entity<TeacherToSubject>()
                .HasOne(tts => tts.Subject)
                .WithMany(subject => subject.Teachers)
                .HasForeignKey(tts => tts.SubjectId);
        }
    }
}
