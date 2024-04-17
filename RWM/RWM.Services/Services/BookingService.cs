using AutoMapper;
using RWM.Domain.Contractors.Services;
using RWM.Domain.Models.Entities;
using RWM.Domain.Models.Enums;
using RWM.Domain.Models.Views;
using RWM.Services.Helpers;

namespace RWM.Services.Services
{
    public class BookingService : IBookingService
    {
        private readonly IMapper _mapper;
        public BookingService(IMapper mapper) =>
            _mapper = mapper;

        public BookingView ConvertBookingToView(Booking booking)
        {
            // Convert entity to view
            var view = _mapper.Map<BookingView>(booking);

            // Compute booking price and other information needed to compute
            view.Days = DateHelper.GetDays(view.StartAt, view.EndAt);
            view.ReservationPercentage = 10;
            view.Total = Math.Round((view.Days * view.Rate), 2);
            view.ReservationFee = Math.Round((view.ReservationPercentage / 100) * view.Total, 2);
            view.PaidAmount = booking.Payments.Where(data => data.Status == PaymentStatus.Completed)
                                              .Sum(data => data.Amount);
            view.Balance = Math.Round((view.Total - view.PaidAmount), 2);   

            return view;
        }
    }
}
