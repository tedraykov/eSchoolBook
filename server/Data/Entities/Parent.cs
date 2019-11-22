using System.Collections.Generic;

namespace SchoolBook.Data.Entities
{
    public class Parent
    {
        public int Id { get; set; }
        public ICollection<Student> Children { get; set; }
        public User User { get; set; }
    }
}
