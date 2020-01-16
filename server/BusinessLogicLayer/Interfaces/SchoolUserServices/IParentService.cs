
using System.Threading.Tasks;
using SchoolBook.BusinessLogicLayer.DTOs.Models.SchoolUserModels;

namespace SchoolBook.BusinessLogicLayer.Interfaces.SchoolUserServices
{
    public interface IParentService
    {
        Task AddParent(ParentModel teacher);
    }
}
