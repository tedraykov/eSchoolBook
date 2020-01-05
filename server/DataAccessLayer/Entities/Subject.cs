using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolBook.DataAccessLayer.Entities
{
    public class Subject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string Name { get; set; }

        public int GradeYear { get; set; }

        public ICollection<ClassToSubject> Classes { get; set; } = new List<ClassToSubject>();

        public ICollection<TeacherToSubject> Teachers { get; set; } = new List<TeacherToSubject>();
    }
}
