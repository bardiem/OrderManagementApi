using Application.Interfaces;
using MediatR;

namespace Application.Commands;

public record CreateOrderCommand : IRequest<int>
{
    public IList<string> OrderItems { get; set; }

    public decimal? Price { get; set; }

    public byte? Status { get; set; }

    public int CustomerId { get; set; }
}

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
{
    private readonly IOrderRepository _orderRepository;

    public CreateOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<int> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        return await _orderRepository.CreateOrder(command, cancellationToken);
    }
}