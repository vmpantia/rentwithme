using MediatR;
using Microsoft.AspNetCore.Mvc;
using RWM.Core.Models.Queries;
using RWM.Core.Models.Views;

namespace RWM.WebApi.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : BaseController
    {
        public CustomerController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomersAsync() =>
            await HandleRequestAsync<GetAllCustomersQuery, IEnumerable<CustomerView>>(new GetAllCustomersQuery());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerByIdAsync(Guid id) =>
            await HandleRequestAsync<GetCustomerByIdQuery, CustomerView>(new GetCustomerByIdQuery(id));
    }
}
