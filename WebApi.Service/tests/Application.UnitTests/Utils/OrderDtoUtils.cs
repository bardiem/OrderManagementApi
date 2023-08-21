namespace Application.UnitTests.Utils;


internal class OrderDtoUtils
{
    public static void AssertOrderDto(OrderDTO orderDto1, OrderDTO orderDto2)
    {
        orderDto1.Status.Should().Be(orderDto2.Status);
        orderDto1.Id.Should().Be(orderDto2.Id);
        orderDto1.Price.Should().Be(orderDto2.Price);
        orderDto1.OrderItems.Should().BeEquivalentTo(orderDto2.OrderItems);
    }
}