using ClassPlanner.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ClassPlanner.Domain.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task Create (TEntity entity);
        Task Delete (Guid id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllActives();
        Task<TEntity> GetById(Guid id);
        Task Update(Guid Id, TEntity entity);
        bool EntityExists(Guid id);
    }
}
