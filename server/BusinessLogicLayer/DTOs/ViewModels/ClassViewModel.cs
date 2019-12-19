using SchoolBook.DataAccessLayer.Entities.SchoolUserEntities;

namespace SchoolBook.BusinessLogicLayer.DTOs.ViewModels
{
    public class ClassViewModel
    {
        public string Id { get; set; }

        public int StartYear { get; set; }

        public int Grade { get; set; }

        public char GradeLetter { get; set; }

        public Teacher ClassTeacher { get; set; }
    }
}