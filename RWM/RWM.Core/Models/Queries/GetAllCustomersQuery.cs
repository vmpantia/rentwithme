using MediatR;
using RWM.Core.Models.Views;

namespace RWM.Core.Models.Queries
{
    public record GetAllCustomersQuery : IRequest<IEnumerable<CustomerView>> { }
}
