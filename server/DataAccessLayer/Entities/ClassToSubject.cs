using System;

namespace SchoolBook.DataAccessLayer.Entities
{
    public class ClassToSubject
    {
        public string ClassId { get; set; }
        public Class Class { get; set; }
        public string SubjectId { get; set; }
        public Subject Subject { get; set; }

        public string WeekDay { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
    }
}
