using SchoolBook.DataAccessLayer.Entities.SchoolUserEntities;

namespace SchoolBook.DataAccessLayer.Entities
{
    public class TeacherToSubject
    {
        public string TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public string SubjectId { get; set; }

        public Subject Subject { get; set; }
    }
}
