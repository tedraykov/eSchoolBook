using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolBook.Data.Entities;

namespace SchoolBook.Data
{
    public class SchoolBookContext : IdentityDbContext<User>
    {
        public SchoolBookContext(DbContextOptions<SchoolBookContext> options): base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Principal> Principals { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Class> Classes { get; set; } 
    }
}