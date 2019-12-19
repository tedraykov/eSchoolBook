using System.Collections.Generic;

namespace SchoolBook.DataAccessLayer.Entities.SchoolUserEntities
{
    public class Parent : SchoolUser
    {
        public ICollection<Student> Children { get; set; } = new List<Student>();
    }
}
