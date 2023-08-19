using Application.Commands;
using Application.DTOs;
using Infrastructure.Common.Enums;
using Infrastructure.Common.Persistence.Entities;

namespace Application.Mappers;

public class OrderMapper
{
    public OrderDTO ToDto(OrderEntity entity)
    {
        var dto = new OrderDTO
        {
            Price = entity.Price.Value,
            Status = (byte)entity.Status.Value,
            OrderItems = entity.OrderItems.Split(","),
            Id = entity.Id
        };
        return dto;
    }

    public OrderEntity ToEntity(CreateOrderCommand createOrderCommand)
    {
        var entity = new OrderEntity
        {
            Price = createOrderCommand.Price,
            Status = (OrderStatusEnum)createOrderCommand.Status,
            OrderItems = string.Join(",", createOrderCommand.OrderItems),
            CustomerId = createOrderCommand.CustomerId,
        };

        return entity;
    }
}
