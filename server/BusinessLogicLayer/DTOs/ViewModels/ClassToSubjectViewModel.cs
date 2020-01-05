using System;

namespace SchoolBook.BusinessLogicLayer.DTOs.ViewModels
{
    public class ClassToSubjectViewModel
    {
        public string ClassId { get; set; }
        
        public string SubjectId { get; set; }
        
        public string WeekDay { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
    }
}