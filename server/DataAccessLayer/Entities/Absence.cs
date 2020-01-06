using System;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolBook.DataAccessLayer.Entities;
using SchoolBook.DataAccessLayer.Entities.SchoolUserEntities;

namespace SchoolBook.DataAccessLayer.Entities
{
    public class Absence
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public Student Student { get; set; }

        public Subject Subject { get; set; }
        
        public Teacher Teacher { get; set; }

        public bool IsFullAbsence { get; set; }

        public bool IsExcused { get; set; }
        
        public DateTime DateCreated { get; set; }
        
        public DateTime DateModified { get; set; }
    }
}
