using System;

namespace SchoolBook.Data.Entities
{
    public class Grade
    {
        public int Id { get; set; }
        public int ValueNum { get; set; }
        public string ValueWord { get; set; }
        public DateTime Timestamp { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}