namespace Infrastructure.Common.Settings;

public record ServiceBusTopicSettings
{
    public string ConnectionString { get; set; }

    public string TopicName { get; set; }

    public string SubscriptionName { get; set; }
}

