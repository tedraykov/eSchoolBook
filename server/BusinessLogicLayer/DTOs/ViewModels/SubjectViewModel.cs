using System.Collections.Generic;
using SchoolBook.BusinessLogicLayer.DTOs.Models.SchoolUserModels;
using SchoolBook.DataAccessLayer.Entities.SchoolUserEntities;

namespace SchoolBook.BusinessLogicLayer.DTOs.ViewModels
{
    public class SubjectViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Signature { get; set; }

        public int GradeYear { get; set; }
        
        public ICollection<MinimalSchoolUserModel> Teachers { get; set; } = new List<MinimalSchoolUserModel>();
    }
}