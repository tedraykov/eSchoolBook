namespace SchoolBook.BusinessLogicLayer.Interfaces
{
    public interface ISchoolService
    {
        object GetAll();

        void AddDirector();

        object UpdateSchool();
    }
}
