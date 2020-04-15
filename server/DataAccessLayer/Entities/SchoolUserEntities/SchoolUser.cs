using System.ComponentModel.DataAnnotations.Schema;
using SchoolBook.BusinessLogicLayer.DTOs.Enums;

namespace SchoolBook.DataAccessLayer.Entities.SchoolUserEntities
{
    public class SchoolUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string Pin { get; set; }

        public string Address { get; set; }

        public string Town { get; set; }

        public School School { get; set; }

        public User User { get; set; }

        public RoleTypes Role { get; set; }
    }
}
