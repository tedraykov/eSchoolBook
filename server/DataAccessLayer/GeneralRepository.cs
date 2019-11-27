using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolBook.DataAccessLayer.Interfaces;

namespace SchoolBook.DataAccessLayer
{
    public class GeneralRepository<TEntity> : IGeneralRepository<TEntity> 
        where TEntity : class
    {
        private readonly SchoolBookContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GeneralRepository(SchoolBookContext schoolBookContext)
        {
            this._context = schoolBookContext;
            this._dbSet = _context.Set<TEntity>();
        }
        
        public IQueryable<TEntity> Query()
        {
            return this._dbSet;
        }

        public async Task<TEntity> GetById(object id)
        {
            return await this._dbSet.FindAsync(id);
        }

        public async Task Create(TEntity entity)
        {
            await this._dbSet.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            this._dbSet.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            this._dbSet.Remove(entity);
        }
        
        public Task<int> SaveChanges()
        {
            return this._context.SaveChangesAsync();
        }
    }
}