using System.Collections.Generic;

namespace SchoolBook.Data.Entities
{
    public class Student
    {
        public int StartYear { get; set; }
        public School School { get; set; }
        public Class Class { get; set; }
        public IEnumerable<Grade> Grades { get; set; }
        public IEnumerable<Absence> Absences { get; set; }
        public User User { get; set; }
    }
}