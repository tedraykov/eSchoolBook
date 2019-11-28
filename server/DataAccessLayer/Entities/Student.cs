using System.Collections.Generic;

namespace SchoolBook.DataAccessLayer.Entities
{
    public class Student
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string Pin { get; set; }

        public string Address { get; set; }

        public string Town { get; set; }

        public int StartYear { get; set; }

        public School School { get; set; }

        public Class Class { get; set; }

        public ICollection<StudentToGrade> Grades { get; set; }

        public ICollection<Absence> Absences { get; set; }

        public User User { get; set; }
    }
}
