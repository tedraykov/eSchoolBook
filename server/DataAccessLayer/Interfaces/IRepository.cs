using System.Linq;
using System.Threading.Tasks;

namespace SchoolBook.DataAccessLayer.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Query();
 
        Task<TEntity> GetById(int id);
 
        Task<TEntity> Create(TEntity entity);
 
        Task<TEntity> Update(int id, TEntity entity);
 
        Task Delete(int id);
    }
}