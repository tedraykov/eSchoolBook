using System;

namespace SchoolBook.BusinessLogicLayer.DTOs.ViewModels
{
    public class SubjectOnlyViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Signature { get; set; }

        public string Grade { get; set; }
        
        public string WeekDay { get; set; }
        
        public TimeSpan StartTime { get; set; }
        
        public TimeSpan EndTime { get; set; }
    }
}