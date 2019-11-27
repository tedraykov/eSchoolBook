using System;
using System.Collections;
using System.Collections.Generic;

namespace SchoolBook.DataAccessLayer.Entities
{
    public class Grade
    {
        public string Id { get; set; }

        public int ValueNum { get; set; }

        public string ValueWord { get; set; }

        public ICollection<StudentToGrade> Students { get; set; }
    }
}
