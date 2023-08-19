using Application.Commands;
using Application.DTOs;
using Application.Interfaces;
using Application.Mappers;
using Infrastructure.Common.Exceptions;
using Infrastructure.Common.Persistence;
using Infrastructure.Common.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;
    private readonly OrderMapper _orderMapper;
    private readonly IDateTime _dateTime;

    public OrderRepository(ApplicationDbContext context, OrderMapper orderMapper, IDateTime dateTime)
    {
        _context = context;
        _orderMapper = orderMapper;
        _dateTime = dateTime;
    }

    public async Task<int> CreateOrder(CreateOrderCommand createOrderCommand, CancellationToken cancellationToken)
    {
        var order = _orderMapper.ToEntity(createOrderCommand);
        order.Created = _dateTime.UtcNow;
        order.LastModified = _dateTime.UtcNow;

        await _context.AddAsync(order);
        await _context.SaveChangesAsync(cancellationToken);

        return order.Id;
    }

    public async Task<IList<OrderDTO>> GetAllOrders(CancellationToken cancellationToken)
    {
        var orders = await _context.Orders.ToListAsync();
        var mapped = orders.Select(o => _orderMapper.ToDto(o)).ToList();

        return mapped;
    }

    public async Task<OrderDTO> GetOrderById(int orderId, CancellationToken cancellationToken)
    {
        var order = await _context.Orders.FirstAsync(o => o.Id == orderId);

        if (order == null)
        {
            throw new NotFoundException("Order not found.");
        }

        var mapped = new OrderDTO
        {
            Id = order.Id,
            Price = order.Price.Value,
            OrderItems = order.OrderItems.Split(","),
        };

        return mapped;
    }
}