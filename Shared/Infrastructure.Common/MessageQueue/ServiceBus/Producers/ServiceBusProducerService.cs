using Azure.Messaging.ServiceBus;
using Infrastructure.Common.MessageQueue.Base.Interfaces;
using Infrastructure.Common.Settings;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Infrastructure.Common.MessageQueue.ServiceBus.Producer;

public class ServiceBusProducerService<T> : IMessageProducerService<T> where T : IMessageBase
{
    private readonly IOptions<ServiceBusTopicSettings> _topicSettings;

    public ServiceBusProducerService(IOptions<ServiceBusTopicSettings> sbSettings)
    {
        _topicSettings = sbSettings;
    }

    public async Task ProduceAsync(T data)
    {
        var client = new ServiceBusClient(_topicSettings.Value.ConnectionString);
        var sender = client.CreateSender(_topicSettings.Value.TopicName);

        var body = JsonSerializer.Serialize(data);
        var message = new ServiceBusMessage(body);

        try
        {
            await sender.SendMessageAsync(message);
        }
        catch (Exception)
        {
            //TODO: logging and error handling
        }
        finally
        {
            await sender.DisposeAsync();
            await client.DisposeAsync();
        }
    }
}