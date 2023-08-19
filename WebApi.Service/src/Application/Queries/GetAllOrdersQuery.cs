using Application.DTOs;
using Application.Interfaces;
using MediatR;

namespace Application.Queries;

public class GetAllOrdersQuery : IRequest<List<OrderDTO>>
{
}

public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<OrderDTO>>
{
    private readonly IOrderRepository _orderRepository;

    public GetAllOrdersQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<List<OrderDTO>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetAllOrders(cancellationToken);
        return orders.ToList();
    }
}