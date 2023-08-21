﻿using Application.Commands;
using Application.DTOs;

namespace Application.Interfaces;

public interface IOrderRepository
{
    Task<OrderDTO> CreateOrder(CreateOrderCommand createOrderCommand, CancellationToken cancellationToken);

    Task<OrderDTO> GetOrderById(int orderId, CancellationToken cancellationToken);

    Task<IList<OrderDTO>> GetAllOrders(CancellationToken cancellationToken);
}
