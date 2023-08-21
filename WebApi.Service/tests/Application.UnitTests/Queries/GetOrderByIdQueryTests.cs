using Application.Queries;
using Application.UnitTests.Utils;

namespace Application.UnitTests.Queries;

public class GetOrderByIdQueryHandlerTests
{
    [Fact]
    public async Task Handle_WhenOrderFound_ReturnsOrderDTO()
    {
        // Arrange
        var orderRepositoryMock = Substitute.For<IOrderRepository>();

        var orderDto = new OrderDTO
        {
            Id = 1,
            OrderItems = new List<string> { "code1", "code2" },
            Price = 100m,
            Status = 0
        };

        orderRepositoryMock.GetOrderById(orderDto.Id, Arg.Any<CancellationToken>())
                       .Returns(orderDto);

        var query = new GetOrderByIdQuery { OrderId = orderDto.Id };


        // Act
        var handler = new GetOrderByIdQueryHandler(orderRepositoryMock);
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        OrderDtoUtils.AssertOrderDto(orderDto, result);
    }

    [Fact]
    public async Task Handle_WhenOrderNotFound_ReturnsNull()
    {
        // Arrange
        var orderRepository = Substitute.For<IOrderRepository>();

        var orderId = 1;
        
        orderRepository.GetOrderById(orderId, Arg.Any<CancellationToken>())
                       .Returns((OrderDTO)null);

        var query = new GetOrderByIdQuery { OrderId = orderId };

        // Act
        var handler = new GetOrderByIdQueryHandler(orderRepository);
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().BeNull();
    }
}