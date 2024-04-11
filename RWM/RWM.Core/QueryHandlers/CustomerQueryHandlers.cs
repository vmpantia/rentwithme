using AutoMapper;
using MediatR;
using RWM.Core.Models.Queries;
using RWM.Core.Models.Views;
using RWM.Domain.Contractors.Repositories;
using RWM.Domain.Models.Enums;

namespace RWM.Core.QueryHandlers
{
    public class CustomerQueryHandlers :
        IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomerView>>,
        IRequestHandler<GetCustomerByIdQuery, CustomerView>,
        IRequestHandler<GetCustomerBookingsById, IEnumerable<BookingView>>,
        IRequestHandler<GetCustomerBookingById, BookingView>
    {
        private readonly ICustomerRepository _customer;
        private readonly IBookingRepository _booking;
        private readonly IMapper _mapper;
        public CustomerQueryHandlers(ICustomerRepository customer, IBookingRepository booking, IMapper mapper)
        {
            _customer = customer;
            _booking = booking;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerView>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            // Get customers that is NOT deleted
            var customers = await _customer.GetCustomersFullInfoAsync(data => data.Status != CommonStatus.Deleted);

            // Convert entity to view
            return _mapper.Map<IEnumerable<CustomerView>>(customers);
        }

        public async Task<CustomerView> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            // Get customer by id
            var customer = await _customer.GetCustomerFullInfoAsync(data => data.Id == request.CustomerId &&
                                                                            data.Status != CommonStatus.Deleted);

            // Check if customer found 
            if (customer is null) throw new Exception("Customer cannot be found in the database.");

            // Convert entity to view
            return _mapper.Map<CustomerView>(customer);
        }

        public async Task<IEnumerable<BookingView>> Handle(GetCustomerBookingsById request, CancellationToken cancellationToken)
        {
            // Get customer bookings by id
            var bookings = await _booking.GetBookingsFullInfoAsync(data => data.CustomerId == request.CustomerId &&
                                                                           data.Status != BookingStatus.Deleted);
            // Convert entity to view
            return _mapper.Map<IEnumerable<BookingView>>(bookings);
        }

        public async Task<BookingView> Handle(GetCustomerBookingById request, CancellationToken cancellationToken)
        {
            // Get customer bookings by id
            var booking = await _booking.GetBookingFullInfoAsync(data => data.Id == request.BookingId && 
                                                                         data.CustomerId == request.CustomerId &&
                                                                         data.Status != BookingStatus.Deleted);

            // Check if customer booking found 
            if (booking is null) throw new Exception("Customer booking cannot be found in the database.");

            // Convert entity to view
            return _mapper.Map<BookingView>(booking);
        }
    }
}
