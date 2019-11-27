using System.Collections.Generic;

namespace SchoolBook.DataAccessLayer.Entities
{
    public class Class
    {
        public string Id { get; set; }

        public int StartYear { get; set; }

        public int Grade { get; set; }

        public char GradeLetter { get; set; }

        public Teacher ClassTeacher { get; set; }
        public ICollection<ClassToSubject> Subjects { get; set; }
    }
}
