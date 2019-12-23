using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBook.DataAccessLayer.Interfaces
{
    public interface IGeneralRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Query();
 
        TEntity GetById(object id);
        
        List<TEntity> GetWithoutTracking();
 
        void Create(TEntity entity);
        
        void CreateWithoutSaving(TEntity entity);
 
        void Update(TEntity entity);
 
        void UpdateWithoutSaving(TEntity entity);
 
        void Delete(TEntity entity);
        
        int SaveChanges();
    }
}