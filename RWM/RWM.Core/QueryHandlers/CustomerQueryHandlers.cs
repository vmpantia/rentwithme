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
        IRequestHandler<GetCustomerByIdQuery, CustomerView>
    {
        private readonly ICustomerRepository _customer;
        private readonly IMapper _mapper;
        public CustomerQueryHandlers(ICustomerRepository customer, IMapper mapper)
        {
            _customer = customer;
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
            var customer = await _customer.GetCustomerFullInfoAsync(data => data.Id == request.Id &&
                                                                            data.Status != CommonStatus.Deleted);

            // Check if customer found 
            if (customer is null) throw new Exception("Customer cannot be found in the database.");

            // Convert entity to view
            return _mapper.Map<CustomerView>(customer);
        }
    }
}
