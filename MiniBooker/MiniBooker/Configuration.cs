using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MiniBooker.Flights;
using MiniBooker.Hotels;
using static System.Net.Mime.MediaTypeNames;

public static class Configuration
{
    public static IConfiguration GetConfiguration(string basePath = null)
    {
        basePath ??= Directory.GetCurrentDirectory();
        var environmentVariable = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        return new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environmentVariable}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

    }

    public static IServiceProvider CreateServices(IConfiguration configuration)
    {
        var serviceProvider = new ServiceCollection()
            .AddLogging(configure =>  // Add logging
            {
                configure.AddConfiguration(configuration.GetSection("Logging"));
                configure.AddConsole();
            })
            .AddSingleton<FlightService>()
            .AddSingleton<HotelService>()
            .Configure<SabreApiOptions>(configuration.GetSection("Sabre"))
            .BuildServiceProvider();

        return serviceProvider;
    }
}
