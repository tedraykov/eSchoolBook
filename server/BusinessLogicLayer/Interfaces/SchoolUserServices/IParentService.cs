using System.Collections.Generic;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels.SchoolUsers.Parent;

namespace SchoolBook.BusinessLogicLayer.Interfaces.SchoolUserServices
{
    public interface IParentService
    {
        IEnumerable<ParentViewModel> GetAllParentsFromSchool(string schoolId);

        ParentDialogViewModel GetParentDialogData(string parentId);
    }
}