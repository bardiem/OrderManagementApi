using Application.Commands;
using Application.DTOs;

namespace Application.Interfaces;

public interface ICustomerRepository
{
    Task<int> CreateCustomer(CreateCustomerCommand createCustomerCommand, CancellationToken cancellationToken);

    Task<IList<CustomerDTO>> GetAllCustomers(CancellationToken cancellationToken);
}
