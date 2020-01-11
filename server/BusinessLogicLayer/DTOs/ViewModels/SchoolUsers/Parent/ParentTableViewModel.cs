using System.Collections.Generic;

namespace SchoolBook.BusinessLogicLayer.DTOs.ViewModels.SchoolUsers.Parent
{
    public class ParentTableViewModel
    {
        public string SchoolUserId { get; set; }
        
        public string FullName { get; set; }
        
        public string Address { get; set; }
        
        public ICollection<string> Children { get; set; }
    }
}