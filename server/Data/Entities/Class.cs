using System.Collections.Generic;

namespace SchoolBook.Data.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public int StartYear { get; set; }
        public int Grade { get; set; }
        public char GradeLetter { get; set; }
        public Teacher ClassTeacher { get; set; }
        public IEnumerable<Class> Classes { get; set; }
    }
}