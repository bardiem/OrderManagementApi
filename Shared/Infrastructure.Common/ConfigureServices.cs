using Infrastructure.Common.Persistence;
using Infrastructure.Common.Services;
using Infrastructure.Common.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Common;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureCommonServices(this IServiceCollection services, IConfiguration configuration)
    {
        ConfigureTransactionDbContext(services, configuration);

        services.AddTransient<IDateTime, DateTimeService>();

        return services;
    }

    private static void ConfigureTransactionDbContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("OrderManagementApi"));
    }
}
