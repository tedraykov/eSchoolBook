using System.Collections.Generic;
using SchoolBook.BusinessLogicLayer.DTOs.Models.SchoolUserModels;
using SchoolBook.DataAccessLayer.Entities.SchoolUserEntities;

namespace SchoolBook.BusinessLogicLayer.DTOs.ViewModels
{
    public class SubjectViewModel : SubjectOnlyViewModel
    {
        public ICollection<MinimalSchoolUserModel> Teachers { get; set; } = new List<MinimalSchoolUserModel>();
    }
}