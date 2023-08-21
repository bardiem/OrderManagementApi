using Infrastructure.Common.Settings;
using Infrastructure.Consumers;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHostedService<SBCreatedOrdersConsumer>();

        services.Configure<ServiceBusTopicSettings>(configuration.GetSection("ServiceBusTopicSettings"));

        services.AddSingleton<CustomerOrdersCounterService>();

        return services;
    }
}