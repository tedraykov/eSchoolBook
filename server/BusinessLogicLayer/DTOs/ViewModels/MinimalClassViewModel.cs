using SchoolBook.DataAccessLayer.Entities.SchoolUserEntities;

namespace SchoolBook.BusinessLogicLayer.DTOs.ViewModels
{
    public class MinimalClassViewModel
    {
        public string Id { get; set; }
        
        public int Grade { get; set; }
        
        public string GradeLetter { get; set; }
    }
}