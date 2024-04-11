using Microsoft.EntityFrameworkCore;
using RWM.Domain.Contractors.Repositories;
using RWM.Domain.Models.Entities;
using RWM.Infrastructure.Databases.Contexts;
using System.Linq.Expressions;

namespace RWM.Infrastructure.Databases.Repositories
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(RWMDbContext context) : base(context) { }

        public async Task<IEnumerable<Booking>> GetBookingsFullInfoAsync(Expression<Func<Booking, bool>> expression) =>
            await base.GetByExpression(expression)
                      .Include(tbl => tbl.Customer)
                      .Include(tbl => tbl.Vehicle)
                        .ThenInclude(tbl => tbl.VehicleType)
                      .Include(tbl => tbl.Payments)
                      .ToListAsync();

        public async Task<Booking?> GetBookingFullInfoAsync(Expression<Func<Booking, bool>> expression) =>
            await base.GetByExpression(expression)
                      .Include(tbl => tbl.Customer)
                      .Include(tbl => tbl.Vehicle)
                        .ThenInclude(tbl => tbl.VehicleType)
                      .Include(tbl => tbl.Payments)
                      .FirstOrDefaultAsync();
    }
}
