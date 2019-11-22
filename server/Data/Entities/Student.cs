using System.Collections.Generic;

namespace SchoolBook.Data.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public int StartYear { get; set; }
        public School School { get; set; }
        public Class Class { get; set; }
        public ICollection<Grade> Grades { get; set; }
        public ICollection<Absence> Absences { get; set; }
        public User User { get; set; }
    }
}
