using System;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolBook.DataAccessLayer.Entities.SchoolUserEntities;

namespace SchoolBook.DataAccessLayer.Entities
{
    public class StudentToGrade
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        
        public string StudentId { get; set; }

        public Student Student { get; set; }

        public string GradeId { get; set; }

        public Grade Grade { get; set; }

        public string SubjectId { get; set; }

        public Subject Subject { get; set; }
        
        public Teacher Teacher { get; set; }

        public DateTime DateCreated { get; set; }
        
        public DateTime DateModified { get; set; }
    }
}
