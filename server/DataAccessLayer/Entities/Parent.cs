using System.Collections.Generic;

namespace SchoolBook.DataAccessLayer.Entities
{
    public class Parent: SchoolUser
    {
        public ICollection<Student> Children { get; set; }

        public User User { get; set; }
    }
}
