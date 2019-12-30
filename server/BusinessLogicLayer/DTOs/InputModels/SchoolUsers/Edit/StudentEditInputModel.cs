using System.ComponentModel.DataAnnotations;

namespace SchoolBook.BusinessLogicLayer.DTOs.InputModels.SchoolUsers.Edit
{
    public class StudentEditInputModel : SchoolUserInputModel
    {
        public string ClassId { get; set; }
    }
}
