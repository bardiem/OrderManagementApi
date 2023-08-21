using Application.Commands;
using Application.UnitTests.Utils;
using Infrastructure.Common.MessageQueue;
using Infrastructure.Common.MessageQueue.Models;

namespace Application.UnitTests.Commands;

public class CreateOrderCommandHandlerTests
{
    [Fact]
    public async Task Handle_WhenValidCommand_ReturnsOrderDTO_AndProducesMessage()
    {
        // Arrange
        var orderRepositoryMock = Substitute.For<IOrderRepository>();
        var producerMock = Substitute.For<IMessageProducerService<NewOrderCreatedMessage>>();
        var handler = new CreateOrderCommandHandler(orderRepositoryMock, producerMock);

        var command = new CreateOrderCommand
        {
            Price = 100.0m,
            CustomerId = 1
        };

        var orderDTO = new OrderDTO
        {
            Id = 1,
            OrderItems = new List<string> { "code1", "code2" },
            Price = 100m,
            Status = 0
        };

        orderRepositoryMock.CreateOrder(command, Arg.Any<CancellationToken>())
                      .Returns(orderDTO);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        OrderDtoUtils.AssertOrderDto(result, orderDTO);

        await orderRepositoryMock.Received(1).CreateOrder(Arg.Is<CreateOrderCommand>(cmd => cmd.CustomerId == command.CustomerId && cmd.Price == command.Price), Arg.Any<CancellationToken>());
        await producerMock.Received(1).ProduceAsync(Arg.Is<NewOrderCreatedMessage>(msg => msg.CustomerId == command.CustomerId));
    }


    [Fact]
    public async Task Handle_WhenInvalidCommand_ThrowsException_AndNotProducesMessage()
    {
        // Arrange
        var exceptionMessage = "Argument exception";

        var orderRepositoryMock = Substitute.For<IOrderRepository>();
        var producerMock = Substitute.For<IMessageProducerService<NewOrderCreatedMessage>>();
        var handler = new CreateOrderCommandHandler(orderRepositoryMock, producerMock);

        var command = new CreateOrderCommand
        {
            Price = 100.0m
        };


        orderRepositoryMock.CreateOrder(Arg.Any<CreateOrderCommand>(), Arg.Any<CancellationToken>())
                          .ThrowsAsync(new Exception(exceptionMessage));

        // Act
        try
        {
            await handler.Handle(command, CancellationToken.None);
            true.Should().BeFalse();
        }
        catch (Exception ex)
        {
            ex.Message.Should().Be(exceptionMessage);
            await orderRepositoryMock.Received(1).CreateOrder(Arg.Is<CreateOrderCommand>(cmd => cmd.CustomerId == command.CustomerId && cmd.Price == command.Price), Arg.Any<CancellationToken>());
            await producerMock.DidNotReceive().ProduceAsync(Arg.Is<NewOrderCreatedMessage>(msg => msg.CustomerId == command.CustomerId));
        }
    }

    
}
