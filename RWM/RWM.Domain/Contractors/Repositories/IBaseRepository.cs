using System.Linq.Expressions;

namespace RWM.Domain.Contractors.Repositories
{
    public interface IBaseRepository<TEntity>
    {
        Task<IQueryable<TEntity>> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity?> GetByIdAsync<TId>(TId id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
    }
}
