using System.Collections.Concurrent;

namespace Infrastructure.Services;

public class CustomerOrdersCounterService
{
    private readonly ConcurrentDictionary<int, int> _customerOrders = new ConcurrentDictionary<int, int>();

    public void AddOrder(int customerId)
    {
        _customerOrders.AddOrUpdate(customerId, 1, (key, oldValue) => oldValue + 1);
    }
}
