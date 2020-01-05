using System;

namespace SchoolBook.BusinessLogicLayer.DTOs.ViewModels
{
    public class T_ClassToSubjectViewModel
    {
        public string Id { get; set; }
        
        public string Grade { get; set; }
        
        public string SubjectName { get; set; }
        
        public string WeekDay { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
    }
}