using Infrastructure.Common.MessageQueue.Base.Interfaces;

namespace Infrastructure.Common.MessageQueue.Models;

public class NewOrderCreatedMessage : IMessageBase
{
    public int CustomerId { get; set; }
}
