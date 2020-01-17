using System.Collections.Generic;

namespace SchoolBook.DataAccessLayer.Entities.SchoolUserEntities
{
    public class Student : SchoolUser
    {
        public int StartYear { get; set; }

        public Class Class { get; set; }
        
        public Parent Parent { get; set; }

        public ICollection<StudentToGrade> Grades { get; set; } =
            new List<StudentToGrade>();

        public ICollection<Absence> Absences { get; set; } =
            new List<Absence>();
    }
}
