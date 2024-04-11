using MediatR;
using RWM.Core.Models.Views;

namespace RWM.Core.Models.Queries
{
    public record GetCustomerBookingById(Guid CustomerId, Guid BookingId) : IRequest<BookingView> { }
}
