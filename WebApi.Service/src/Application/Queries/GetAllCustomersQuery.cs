using Application.DTOs;
using Application.Interfaces;
using MediatR;

namespace Application.Queries;

public class GetAllCustomersQuery : IRequest<List<CustomerDTO>>
{
}

public class GetCustomerQueryHandler : IRequestHandler<GetAllCustomersQuery, List<CustomerDTO>>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<List<CustomerDTO>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers = await _customerRepository.GetAllCustomers(cancellationToken);
        return customers.ToList();
    }
}