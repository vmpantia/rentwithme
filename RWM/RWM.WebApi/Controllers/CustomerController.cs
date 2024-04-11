using MediatR;
using Microsoft.AspNetCore.Mvc;
using RWM.Core.Models.Queries;
using RWM.Core.Models.Views;

namespace RWM.WebApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class CustomerController : BaseController
    {
        public CustomerController(IMediator mediator) : base(mediator) { }

        [HttpGet("customers")]
        public async Task<IActionResult> GetAllCustomersAsync() =>
            await HandleRequestAsync<GetAllCustomersQuery, IEnumerable<CustomerView>>(new GetAllCustomersQuery());

        [HttpGet("customers/{customerId}")]
        public async Task<IActionResult> GetCustomerByIdAsync(Guid customerId) =>
            await HandleRequestAsync<GetCustomerByIdQuery, CustomerView>(new GetCustomerByIdQuery(customerId));

        [HttpGet("customers/{customerId}/bookings")]
        public async Task<IActionResult> GetCustomerBookingsByIdAsync(Guid customerId) =>
            await HandleRequestAsync<GetCustomerBookingsById, IEnumerable<BookingView>>(new GetCustomerBookingsById(customerId));

        [HttpGet("customers/{customerId}/bookings/{bookingId}")]
        public async Task<IActionResult> GetCustomerBookingByIdAsync(Guid customerId, Guid bookingId) =>
            await HandleRequestAsync<GetCustomerBookingById, IEnumerable<BookingView>>(new GetCustomerBookingById(customerId, bookingId));
    }
}
