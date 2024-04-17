using RWM.Domain.Models.Entities;
using RWM.Domain.Models.Views;

namespace RWM.Domain.Contractors.Services
{
    public interface IBookingService
    {
        BookingView ConvertBookingToView(Booking booking);
    }
}
