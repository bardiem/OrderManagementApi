using Infrastructure.Common.MessageQueue.Base.Interfaces;

namespace Infrastructure.Common.MessageQueue;

public interface IMessageProducerService<T> where T : IMessageBase
{
    Task ProduceAsync(T data);
}