using Microsoft.EntityFrameworkCore;
using RWM.Domain.Contractors.Repositories;
using RWM.Infrastructure.Databases.Contexts;
using System.Linq.Expressions;

namespace RWM.Infrastructure.Databases.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        protected RWMDbContext _context;
        protected DbSet<TEntity> _table;
        public BaseRepository(RWMDbContext context)
        {
            _context = context;
            _table = context.Set<TEntity>();
        }

        public async Task<IQueryable<TEntity>> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression) =>
            await Task.Run(() => _table.Where(expression)
                                       .AsNoTracking());

        public async Task<TEntity?> GetByIdAsync<TId>(TId id) =>
            await _table.FindAsync(id);

        public async Task AddAsync(TEntity entity) =>
            await _table.AddAsync(entity);

        public async Task UpdateAsync(TEntity entity) =>
            await Task.Run(() => _table.Update(entity));
    }
}
