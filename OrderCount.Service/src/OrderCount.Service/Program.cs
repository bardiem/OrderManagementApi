using Infrastructure;
using Infrastructure.Common;
using Microsoft.Extensions.Hosting;

namespace OrderCount.Service;

public static class Program
{
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddInfrastructureCommonServices(hostContext.Configuration);
                services.AddInfrastructureServices(hostContext.Configuration);
            });

    public static async Task Main(string[] args)
    {
        var app = CreateHostBuilder(args).Build();

        app.Run();
    }
}
