using System.Linq.Expressions;

namespace RWM.Domain.Contractors.Repositories
{
    public interface IBaseRepository<TEntity>
    {
        Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> expression);
        IQueryable<TEntity> GetByExpression(Expression<Func<TEntity, bool>> expression);
        Task<TEntity?> GetByIdAsync<TId>(TId id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
    }
}
