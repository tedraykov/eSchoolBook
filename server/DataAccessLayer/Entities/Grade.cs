using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolBook.DataAccessLayer.Entities
{
    public class Grade
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public int ValueNum { get; set; }

        public string ValueWord { get; set; }

        public ICollection<StudentToGrade> Students { get; set; }
    }
}
