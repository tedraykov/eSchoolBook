namespace SchoolBook.BusinessLogicLayer.DTOs.Models.SchoolUserModels
{
    public class MinimalStudentModel : MinimalSchoolUserModel
    {
        public int Grade { get; set; }
        public string GradeLetter { get; set; }

        public string Pin { get; set; }
    }
    
}