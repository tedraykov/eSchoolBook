
using System.Threading.Tasks;
using SchoolBook.BusinessLogicLayer.DTOs.Models.SchoolUserModels;
using System.Collections.Generic;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels.SchoolUsers.Parent;

namespace SchoolBook.BusinessLogicLayer.Interfaces.SchoolUserServices
{
    public interface IParentService
    {
        Task AddParent(ParentModel teacher);

        IEnumerable<ParentViewModel> GetAllParentsFromSchool(string schoolId);

        ParentDialogViewModel GetParentDialogData(string parentId);
    }
}