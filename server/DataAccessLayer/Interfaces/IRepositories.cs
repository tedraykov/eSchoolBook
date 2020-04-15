using System.Threading.Tasks;
using SchoolBook.DataAccessLayer.Entities;
using SchoolBook.DataAccessLayer.Entities.SchoolUserEntities;

namespace SchoolBook.DataAccessLayer.Interfaces
{
    public interface IRepositories
    {
        IGeneralRepository<Absence> Absences { get; }

        IGeneralRepository<Class> Classes { get; }
        
        IGeneralRepository<Grade> Grades { get; }
        
        IGeneralRepository<Parent> Parents { get; }
        
        IGeneralRepository<Principal> Principals { get; }
        
        IGeneralRepository<School> Schools { get; }
        
        IGeneralRepository<Student> Students { get; }
        
        IGeneralRepository<Subject> Subjects { get; }
        
        IGeneralRepository<Teacher> Teachers { get; }
        
        IGeneralRepository<SchoolAdmin> SchoolAdmins { get; }

        IGeneralRepository<User> Users { get; }

        IGeneralRepository<SchoolUser> SchoolUsers { get; }
        
        IGeneralRepository<ClassToSubject> ClassToSubject { get; }
        
        IGeneralRepository<StudentToGrade> StudentsToGrades { get; }
        
        IGeneralRepository<TeacherToSubject> TeacherToSubject { get; }

        int SaveChanges();
    }
}
