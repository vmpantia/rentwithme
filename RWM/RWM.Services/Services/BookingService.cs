using AutoMapper;
using RWM.Domain.Contractors.Services;
using RWM.Domain.Models.Entities;
using RWM.Domain.Models.Views;

namespace RWM.Services.Services
{
    public class BookingService : IBookingService
    {
        private readonly IMapper _mapper;
        public BookingService(IMapper mapper) =>
            _mapper = mapper;

        public BookingView ConvertBookingToView(Booking booking)
        {
            var view = _mapper.Map<BookingView>(booking);

            return view;
        }
    }
}
