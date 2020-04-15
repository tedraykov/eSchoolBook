using System.Collections.Generic;

namespace SchoolBook.BusinessLogicLayer.DTOs.ViewModels.SchoolUsers.Parent
{
    public class ParentDialogViewModel : ParentViewModel
    {
        public ICollection<StudentDialogViewModel> ChildrenData { get; set; } = new List<StudentDialogViewModel>();
    }
}