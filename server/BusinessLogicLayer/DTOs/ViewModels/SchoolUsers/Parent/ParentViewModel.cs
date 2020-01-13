using System.Collections.Generic;

namespace SchoolBook.BusinessLogicLayer.DTOs.ViewModels.SchoolUsers.Parent
{
    public class ParentViewModel
    {
        public string SchoolUserId { get; set; }
        
        public string FullName { get; set; }
        
        public string Address { get; set; }
        
        public ICollection<string> Children { get; set; }

        public string Email { get; set; }
    }
}