using System.Collections.Generic;

namespace SchoolBook.Data.Entities
{
    public class Teacher
    {
        public IEnumerable<Subject> Subjects { get; set; }
        public User User { get; set; }
    }
}