using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace OmniUpdate.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOmniUpdateCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DiscordClientOptions>(configuration.GetSection("Discord"));
        services.Configure<UpdateServiceOptions>(configuration.GetSection("UpdateService"));

        services.AddSingleton<DiscordClient>();
        services.AddHostedService<UpdateService>();

        services.AddHttpClient();

        return services;
    }

    public static async Task StartOmniUpdateServicesAsync(this IServiceProvider services)
    {
        var discordClient = services.GetRequiredService<DiscordClient>();
        await discordClient.StartAsync();
    }

    public static async Task StopOmniUpdateServicesAsync(this IServiceProvider services)
    {
        var discordClient = services.GetRequiredService<DiscordClient>();
        await discordClient.StopAsync();
    }
}