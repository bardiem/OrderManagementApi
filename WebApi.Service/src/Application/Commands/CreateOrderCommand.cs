using Application.DTOs;
using Application.Interfaces;
using Infrastructure.Common.MessageQueue;
using Infrastructure.Common.MessageQueue.Models;
using MediatR;

namespace Application.Commands;

public record CreateOrderCommand : IRequest<OrderDTO>
{
    public IList<string> OrderItems { get; set; }

    public decimal? Price { get; set; }

    public byte? Status { get; set; }

    public int CustomerId { get; set; }
}

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderDTO>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMessageProducerService<NewOrderCreatedMessage> _producer;

    public CreateOrderCommandHandler(IOrderRepository orderRepository, IMessageProducerService<NewOrderCreatedMessage> producer)
    {
        _orderRepository = orderRepository;
        _producer = producer;
    }

    public async Task<OrderDTO> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.CreateOrder(command, cancellationToken);

        await _producer.ProduceAsync(new NewOrderCreatedMessage { CustomerId = command.CustomerId });

        return order;
    }
}