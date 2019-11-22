namespace SchoolBook.Data.Entities
{
    public class Principal
    {
        public int Id { get; set; }
        public School School { get; set; }
        public User User { get; set; }
    }
}
