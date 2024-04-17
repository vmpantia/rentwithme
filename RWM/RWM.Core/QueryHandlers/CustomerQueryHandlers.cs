using AutoMapper;
using MediatR;
using RWM.Core.Models.Queries;
using RWM.Domain.Contractors.Repositories;
using RWM.Domain.Contractors.Services;
using RWM.Domain.Models.Enums;
using RWM.Domain.Models.Views;

namespace RWM.Core.QueryHandlers
{
    public class CustomerQueryHandlers :
        IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomerView>>,
        IRequestHandler<GetCustomerByIdQuery, CustomerView>,
        IRequestHandler<GetCustomerBookingsById, IEnumerable<BookingView>>,
        IRequestHandler<GetCustomerBookingById, BookingView>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;
        public CustomerQueryHandlers(ICustomerRepository customerRepository, 
                                     IBookingRepository bookingRepository, 
                                     IBookingService bookingService,
                                     IMapper mapper)
        {
            _customerRepository = customerRepository;
            _bookingRepository = bookingRepository;
            _bookingService = bookingService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerView>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            // Get customers that is NOT deleted
            var customers = await _customerRepository.GetCustomersFullInfoAsync(data => data.Status != CommonStatus.Deleted);

            // Convert entity to view
            return _mapper.Map<IEnumerable<CustomerView>>(customers);
        }

        public async Task<CustomerView> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            // Get customer by id
            var customer = await _customerRepository.GetCustomerFullInfoAsync(data => data.Id == request.CustomerId &&
                                                                                      data.Status != CommonStatus.Deleted);

            // Check if customer found 
            if (customer is null) throw new Exception("Customer cannot be found in the database.");

            // Convert entity to view
            return _mapper.Map<CustomerView>(customer);
        }

        public async Task<IEnumerable<BookingView>> Handle(GetCustomerBookingsById request, CancellationToken cancellationToken)
        {
            // Get customer bookings by id
            var bookings = await _bookingRepository.GetBookingsFullInfoAsync(data => data.CustomerId == request.CustomerId &&
                                                                                     data.Status != BookingStatus.Deleted);
            // Convert entity to view
            return bookings.Select(data => _bookingService.ConvertBookingToView(data))
                           .ToList();
        }

        public async Task<BookingView> Handle(GetCustomerBookingById request, CancellationToken cancellationToken)
        {
            // Get customer bookings by id
            var booking = await _bookingRepository.GetBookingFullInfoAsync(data => data.Id == request.BookingId && 
                                                                                   data.CustomerId == request.CustomerId &&
                                                                                   data.Status != BookingStatus.Deleted);

            // Check if customer booking found 
            if (booking is null) throw new Exception("Customer booking cannot be found in the database.");

            // Convert entity to view
            return _mapper.Map<BookingView>(booking);
        }
    }
}
