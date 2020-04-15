using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolBook.BusinessLogicLayer.DTOs.Models.SchoolUserModels
{
    public class ParentModel : SchoolUserModel
    {
        [Required]
        public IEnumerable<string> ChildrenId { get; set; }
    }
}
