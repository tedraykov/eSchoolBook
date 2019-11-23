using System;
using SchoolBook.DataAccessLayer.Entities;

namespace SchoolBook.DataAccessLayer.Entities
{
    public class Absence
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public bool IsFullAbsence { get; set; }
    }
}
