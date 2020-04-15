using System;
using System.Threading.Tasks;

namespace SchoolBook.DataAccessLayer.Interfaces
{
    public interface ISeeder
    {
        Task Seed();
    }
}
