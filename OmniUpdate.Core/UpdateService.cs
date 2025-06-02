using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace OmniUpdate.Core;

public class UpdateServiceOptions
{
    public TimeSpan CheckInterval { get; set; } = TimeSpan.FromMinutes(30);
    public bool EnableDiscordNotifications { get; set; } = true;
    public bool EnableReleaseNotifications { get; set; } = true;
    public bool EnableCommitNotifications { get; set; } = false;
}

public class UpdateService : BackgroundService
{
    private readonly DiscordClient _discordClient;
    private readonly UpdateServiceOptions _options;
    private readonly ILogger<UpdateService> _logger;
    private DateTimeOffset _lastCheck;

    public UpdateService(
        DiscordClient discordClient,
        IOptions<UpdateServiceOptions> options,
        ILogger<UpdateService> logger)
    {
        _discordClient = discordClient;
        _options = options.Value;
        _logger = logger;
        _lastCheck = DateTimeOffset.UtcNow;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Update service started with check interval: {Interval}", _options.CheckInterval);

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await Task.Delay(_options.CheckInterval, stoppingToken);
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Update service is stopping");
                break;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during update check");
                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }
        }
    }



    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Update service is stopping");
        await base.StopAsync(cancellationToken);
    }
}