using RWM.Domain.Models.Entities;
using System.Linq.Expressions;

namespace RWM.Domain.Contractors.Repositories
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetBookingsFullInfoAsync(Expression<Func<Booking, bool>> expression);
        Task<Booking?> GetBookingFullInfoAsync(Expression<Func<Booking, bool>> expression);
    }
}