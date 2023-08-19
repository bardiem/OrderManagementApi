using Infrastructure.Common.Enums;

namespace Infrastructure.Common.Persistence.Entities;

public class OrderEntity : BaseEntity
{
    public string OrderItems { get; set; }

    public decimal? Price { get; set; }

    public OrderStatusEnum? Status { get; set; }

    public CustomerEntity Customer { get; set; }

    public int CustomerId { get; set; }
}
