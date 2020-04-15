using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolBook.DataAccessLayer.Entities
{
    public class School
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string Name { get; set; }

        public int Number { get; set; }

        public string Address { get; set; }
        
        public ICollection<Class> Classes { get; set; }
    }
}
