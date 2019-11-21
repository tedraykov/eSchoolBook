namespace SchoolBook.Data.Roles
{
    public class StudentRepository
    {
        private readonly SchoolBookContext _ctx;

        public StudentRepository(SchoolBookContext ctx)
        {
            _ctx = ctx;
        }
    }
}