using Application.DTOs;
using Application.Interfaces;
using MediatR;

namespace Application.Queries;

public class GetOrderByIdQuery : IRequest<OrderDTO>
{
    public int OrderId { get; set; }
}

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDTO>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<OrderDTO> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetOrderById(request.OrderId, cancellationToken);
        return order;
    }
}
