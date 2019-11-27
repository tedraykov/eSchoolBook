using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolBook.DataAccessLayer.Interfaces;

namespace SchoolBook.DataAccessLayer.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly SchoolBookContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(SchoolBookContext schoolBookContext)
        {
            this._context = schoolBookContext;
            this._dbSet = _context.Set<TEntity>();
        }
        
        public IQueryable<TEntity> Query()
        {
            return this._dbSet;
        }

        public Task<TEntity> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<TEntity> Create(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<TEntity> Update(int id, TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}