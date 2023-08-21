using Azure.Messaging.ServiceBus;
using Infrastructure.Common.MessageQueue.Base.Interfaces;
using Infrastructure.Common.Settings;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Infrastructure.Common.MessageQueue.ServiceBus.Consumer;

public class ServiceBusConsumerBaseService<TMessage> : BackgroundService, IMessageConsumerService where TMessage : IMessageBase
{
    private readonly IOptions<ServiceBusTopicSettings> _topicSettings;

    public ServiceBusConsumerBaseService(IOptions<ServiceBusTopicSettings> topicSettings)
    {
        _topicSettings = topicSettings;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        await using var client = new ServiceBusClient(_topicSettings.Value.ConnectionString);
        var receiver = client.CreateReceiver(_topicSettings.Value.TopicName, _topicSettings.Value.SubscriptionName);

        while (!cancellationToken.IsCancellationRequested)
        {
            var message = await receiver.ReceiveMessageAsync();

            if (message != null)
            {
                var json = message.Body;
                var deserialized = JsonSerializer.Deserialize<TMessage>(json);

                await ProcessMessage(deserialized, cancellationToken);

                await receiver.CompleteMessageAsync(message);
            }
            else
            {
                await Task.Delay(1000);
            }
        }
    }

    protected virtual Task ProcessMessage(TMessage message, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
