using System;

namespace SchoolBook.Data.Entities
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