using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolBook.DataAccessLayer.Entities.SchoolUserEntities;

namespace SchoolBook.DataAccessLayer.Entities
{
    public class Class
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public int StartYear { get; set; }

        public int Grade { get; set; }

        public char GradeLetter { get; set; }

        public Teacher ClassTeacher { get; set; }

        public School School { get; set; }
        
        public string SchoolId { get; set; }

        public ICollection<ClassToSubject> Subjects { get; set; } = new List<ClassToSubject>();
    }
}
