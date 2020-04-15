using System;

namespace SchoolBook.BusinessLogicLayer.DTOs.ViewModels
{
    public struct S_ClassToSubjectViewModel
    {
        public string Id { get; set; }
        
        public string SubjectName { get; set; }
        
        public string TeacherName { get; set; }
        
        public string WeekDay { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
    }
}