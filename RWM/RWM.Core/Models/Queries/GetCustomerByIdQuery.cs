using MediatR;
using RWM.Domain.Models.Views;

namespace RWM.Core.Models.Queries
{
    public record GetCustomerByIdQuery(Guid CustomerId) : IRequest<CustomerView> { }
}
