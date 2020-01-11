using System.Collections.Generic;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels.SchoolUsers.Parent;

namespace SchoolBook.BusinessLogicLayer.Interfaces.SchoolUserServices
{
    public interface IParentService
    {
        IEnumerable<ParentTableViewModel> GetAllParentsFromSchool(string schoolId);
    }
}