using Application.Interfaces;
using MediatR;

namespace Application.Commands;

public record CreateCustomerCommand : IRequest<int>
{
    public string Email { get; set; }

    public string UserName { get; set; }

    public string PasswordHash { get; set; }
}

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
{
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<int> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        return await _customerRepository.CreateCustomer(command, cancellationToken);
    }
}