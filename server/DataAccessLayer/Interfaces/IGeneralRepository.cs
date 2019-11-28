using System.Linq;
using System.Threading.Tasks;

namespace SchoolBook.DataAccessLayer.Interfaces
{
    public interface IGeneralRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Query();
 
        Task<TEntity> GetById(object id);
 
        Task Create(TEntity entity);
 
        void Update(TEntity entity);
 
        void Delete(TEntity entity);
        
        Task<int> SaveChanges();
    }
}