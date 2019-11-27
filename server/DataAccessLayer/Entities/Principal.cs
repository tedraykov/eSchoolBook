namespace SchoolBook.DataAccessLayer.Entities
{
    public class Principal : SchoolUser
    {
        public School School { get; set; }

        public User User { get; set; }
    }
}
