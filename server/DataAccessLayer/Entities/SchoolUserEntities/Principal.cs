namespace SchoolBook.DataAccessLayer.Entities.SchoolUserEntities
{
    public class Principal : SchoolUser
    {
        public School School { get; set; }
    }
}
