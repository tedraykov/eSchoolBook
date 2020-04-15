﻿using System;
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
                .HasValue<Parent>(RoleTypes.Parent)
                .HasValue<SchoolAdmin>(RoleTypes.SchoolAdmin);
            
            /* Many to many relationships configuration */
            builder.Entity<ClassToSubject>()
                .HasKey(cts => cts.Id);
            builder.Entity<ClassToSubject>()
                .HasOne(cts => cts.Class)
                .WithMany(book => book.Subjects)
                .HasForeignKey(cts => cts.ClassId);
            builder.Entity<ClassToSubject>()
                .HasOne(cts => cts.Subject)
                .WithMany(subject => subject.Classes)
                .HasForeignKey(cts => cts.SubjectId);

            builder.Entity<StudentToGrade>()
                .HasKey(stg => stg.Id);
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
            
            /* Many to one relationship configuration */

            builder.Entity<Class>()
                .HasOne(c => c.School)
                .WithMany(s => s.Classes)
                .IsRequired();
            
            /* Unique constraints configuration */
            builder.Entity<SchoolUser>()
                .HasIndex(su => su.Pin)
                .IsUnique();

            builder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            
            /*Seed data !!! Delete lines 113-122 and */
            builder.Entity<Subject>()
                .HasData(
                    new Subject{Id = Guid.NewGuid().ToString(), Name = "Български език и литература", GradeYear = 1},
                    new Subject{Id = Guid.NewGuid().ToString(), Name = "Математика", GradeYear = 1},
                    new Subject{Id = Guid.NewGuid().ToString(), Name = "Околен свят", GradeYear = 1},
                    new Subject{Id = Guid.NewGuid().ToString(), Name = "Музика", GradeYear = 1},
                    new Subject{Id = Guid.NewGuid().ToString(), Name = "Български език и литература", GradeYear = 2},
                    new Subject{Id = Guid.NewGuid().ToString(), Name = "Математика", GradeYear = 2},
                    new Subject{Id = Guid.NewGuid().ToString(), Name = "Английски език", GradeYear = 2}
                );
        }
    }
}
