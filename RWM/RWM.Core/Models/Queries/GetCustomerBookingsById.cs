using MediatR;
using RWM.Core.Models.Views;

namespace RWM.Core.Models.Queries
{
    public record GetCustomerBookingsById(Guid CustomerId) : IRequest<IEnumerable<BookingView>> { }
}
