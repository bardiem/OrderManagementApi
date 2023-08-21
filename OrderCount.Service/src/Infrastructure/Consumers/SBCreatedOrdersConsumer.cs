using Infrastructure.Common.MessageQueue.Models;
using Infrastructure.Common.MessageQueue.ServiceBus.Consumer;
using Infrastructure.Common.Settings;
using Infrastructure.Services;
using Microsoft.Extensions.Options;

namespace Infrastructure.Consumers;

public class SBCreatedOrdersConsumer : ServiceBusConsumerBaseService<NewOrderCreatedMessage>
{
    private readonly CustomerOrdersCounterService _counterService;
    public SBCreatedOrdersConsumer(IOptions<ServiceBusTopicSettings> topicSettings, CustomerOrdersCounterService counterService) : base(topicSettings)
    {
        _counterService = counterService;
    }

    protected override Task ProcessMessage(NewOrderCreatedMessage message, CancellationToken cancellationToken)
    {
        _counterService.AddOrder(message.CustomerId);
        return Task.CompletedTask;
    }
}
