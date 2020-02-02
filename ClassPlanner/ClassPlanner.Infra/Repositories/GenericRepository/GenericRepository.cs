using ClassPlanner.Infra.Context;
using System;
using System.Threading.Tasks;

namespace ClassPlanner.Infra.Repositories.GenericRepository
{
    public class GenericRepository
    {
        public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
        {
            public readonly MainContext _dbContext;
            public GenericRepository (MainContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task Create (TEntity entity)
            {
                await _dbContext.Set<TEntity>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();
            }

            public async Task Delete (Guid id)
            {
                var entity = await GetById(id);
                _dbContext.Set<Entity>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }

            public IQueryable<TEntity> GetAll ()
            {
                return _dbContext.Set<TEntity>().AsNoTracking();
            }
        }
    }
}
