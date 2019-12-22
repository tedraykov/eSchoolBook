using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolBook.DataAccessLayer.Entities.SchoolUserEntities
{
    public class Student : SchoolUser
    {
        public int StartYear { get; set; }

        public Class Class { get; set; }

        [ForeignKey("Class")] public string ClassId { get; set; }

        public ICollection<StudentToGrade> Grades { get; set; }

        public ICollection<Absence> Absences { get; set; }
    }
}
