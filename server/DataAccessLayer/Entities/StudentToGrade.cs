using System;
using SchoolBook.DataAccessLayer.Entities.SchoolUserEntities;

namespace SchoolBook.DataAccessLayer.Entities
{
    public class StudentToGrade
    {
        public string StudentId { get; set; }

        public Student Student { get; set; }

        public string GradeId { get; set; }

        public Grade Grade { get; set; }

        public string SubjectId { get; set; }

        public Subject Subject { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
