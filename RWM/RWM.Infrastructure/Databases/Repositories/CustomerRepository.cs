using Microsoft.EntityFrameworkCore;
using RWM.Domain.Contractors.Repositories;
using RWM.Domain.Models.Entities;
using RWM.Infrastructure.Databases.Contexts;
using System.Linq.Expressions;

namespace RWM.Infrastructure.Databases.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(RWMDbContext context) : base(context) { }

        public async Task<IEnumerable<Customer>> GetCustomersFullInfoAsync(Expression<Func<Customer, bool>> expression) =>
            await base.GetByExpression(expression)
                      .Include(tbl => tbl.Bookings)
                      .ToListAsync();

        public async Task<Customer?> GetCustomerFullInfoAsync(Expression<Func<Customer, bool>> expression) =>
            await base.GetByExpression(expression)
                      .Include(tbl => tbl.Bookings)
                      .FirstOrDefaultAsync();
    }
}
