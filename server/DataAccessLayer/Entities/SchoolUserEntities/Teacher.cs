using System.Collections.Generic;

namespace SchoolBook.DataAccessLayer.Entities.SchoolUserEntities
{
    public class Teacher : SchoolUser
    {
    public ICollection<TeacherToSubject> Subjects { get; set; } = new List<TeacherToSubject>();
    }
}
