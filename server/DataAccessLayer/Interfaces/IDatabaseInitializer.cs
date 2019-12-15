using System;
using System.Threading.Tasks;

namespace SchoolBook.DataAccessLayer.Interfaces
{
    public interface IDatabaseInitializer
    {
        Task Seed(IServiceProvider provider);
    }
}