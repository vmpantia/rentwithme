using RWM.Domain.Models.Entities;
using System.Linq.Expressions;

namespace RWM.Domain.Contractors.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetCustomersFullInfoAsync(Expression<Func<Customer, bool>> expression);
        Task<Customer?> GetCustomerFullInfoAsync(Expression<Func<Customer, bool>> expression);
    }
}