using System;
using SchoolBook.DataAccessLayer.Entities;
using SchoolBook.DataAccessLayer.Entities.SchoolUserEntities;

namespace SchoolBook.DataAccessLayer.Entities
{
    public class Absence
    {
        public string Id { get; set; }

        public DateTime Timestamp { get; set; }

        public Student Student { get; set; }

        public Subject Subject { get; set; }

        public bool IsFullAbsence { get; set; }
    }
}
