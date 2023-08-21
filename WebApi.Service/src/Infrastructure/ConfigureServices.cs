using Application.Interfaces;
using Infrastructure.Common.MessageQueue;
using Infrastructure.Common.MessageQueue.Models;
using Infrastructure.Common.MessageQueue.ServiceBus.Producer;
using Infrastructure.Common.Settings;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IMessageProducerService<NewOrderCreatedMessage>, ServiceBusProducerService<NewOrderCreatedMessage>>();

        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddTransient<ICustomerRepository, CustomerRepository>();

        services.Configure<ServiceBusTopicSettings>(configuration.GetSection("ServiceBusTopicSettings"));

        return services;
    }
}
