using System.Collections.Generic;

namespace SchoolBook.Data.Entities
{
    public class Parent
    {
        public IEnumerable<Student> Children { get; set; }
        public User User { get; set; }
    }
}