using RWM.Domain.Contractors.Repositories;
using RWM.Domain.Models.Entities;
using System.Linq.Expressions;

namespace RWM.Domain.Contractors.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<Customer> GetCustomerFullInfoAsync(Expression<Func<Customer, bool>> expression);
        Task<IEnumerable<Customer>> GetCustomersFullInfoAsync(Expression<Func<Customer, bool>> expression);
    }
}