using SchoolBook.DataAccessLayer.Entities.SchoolUserEntities;

namespace SchoolBook.BusinessLogicLayer.DTOs.InputModels
{
    public class ClassInputModel
    {
        public int StartYear { get; set; }
        
        public int Grade { get; set; }
        
        public char GradeLetter { get; set; }
    }
}