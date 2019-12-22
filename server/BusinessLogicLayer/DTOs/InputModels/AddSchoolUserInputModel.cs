using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Linq;
using SchoolBook.BusinessLogicLayer.DTOs.Enums;
using SchoolBook.BusinessLogicLayer.DTOs.Models.SchoolUserModels;

namespace SchoolBook.BusinessLogicLayer.DTOs.InputModels
{
    public class AddSchoolUserInputModel
    {
        [Required] public SchoolUserModel BaseUserModel { get; set; }

        [Required] public RoleTypes Role { get; set; }

        public JObject RoleSpecificModel { get; set; }
    }
}
