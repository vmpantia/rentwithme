using MediatR;
using RWM.Domain.Models.Views;

namespace RWM.Core.Models.Queries
{
    public record GetAllCustomersQuery : IRequest<IEnumerable<CustomerView>> { }
}
