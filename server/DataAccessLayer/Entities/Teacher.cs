using System.Collections.Generic;

namespace SchoolBook.DataAccessLayer.Entities
{
    public class Teacher : SchoolUser
    {
        public ICollection<TeacherToSubject> Subjects { get; set; }

        public User User { get; set; }
    }
}
