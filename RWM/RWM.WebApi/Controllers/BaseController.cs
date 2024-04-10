using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RWM.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;
        public BaseController(IMediator mediator) =>
            _mediator = mediator;

        protected async Task<IActionResult> HandleRequestAsync<TRequest, TResult>(TRequest request)
            where TRequest : class
            where TResult : class
        {
            try
            {
                // Check if the request is NULL
                if (request is null)
                    throw new ArgumentNullException(nameof(request));

                // Process the request using mediator
                var response = await _mediator.Send(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
