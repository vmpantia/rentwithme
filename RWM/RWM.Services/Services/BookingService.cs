using AutoMapper;
using RWM.Domain.Commons;
using RWM.Domain.Contractors.Repositories;
using RWM.Domain.Contractors.Services;
using RWM.Domain.Models.Entities;
using RWM.Domain.Models.Enums;
using RWM.Domain.Models.Views;
using RWM.Services.Helpers;

namespace RWM.Services.Services
{
    public class BookingService : IBookingService
    {
        private readonly IConfigurationRepository _configurationRepository;
        private readonly IMapper _mapper;
        public BookingService(IConfigurationRepository configurationRepository, IMapper mapper)
        {
            _configurationRepository = configurationRepository;
            _mapper = mapper;
        }

        public BookingView ConvertBookingToView(Booking booking)
        {
            // Convert entity to view
            var view = _mapper.Map<BookingView>(booking);

            // Compute booking price and other information needed to compute
            view.Days = DateHelper.GetDays(view.StartAt, view.EndAt);
            view.ReservationPercentage = _configurationRepository.GetValue<decimal>("BOOKING", "RESERVATION_PERCENTAGE");
            view.Total = Math.Round((view.Days * view.Rate), Constant.DECIMALS_PLACE);
            view.ReservationFee = Math.Round((view.ReservationPercentage / Constant.ONE_HUNDRED_PERCENT) * view.Total, Constant.DECIMALS_PLACE);
            view.PaidAmount = booking.Payments.Where(data => data.Status == PaymentStatus.Completed)
                                              .Sum(data => data.Amount);
            view.Balance = Math.Round((view.Total - view.PaidAmount), Constant.DECIMALS_PLACE);   

            return view;
        }
    }
}
