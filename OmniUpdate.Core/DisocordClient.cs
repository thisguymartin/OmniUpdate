using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace OmniUpdate.Core;

public class DiscordClientOptions
{
    public string Token { get; set; } = string.Empty;
    public string GuildId { get; set; } = string.Empty;
    public string ChannelId { get; set; } = string.Empty;
}

public class DiscordClient : IDisposable
{
    private readonly DiscordSocketClient _client;
    private readonly ILogger<DiscordClient> _logger;
    private readonly DiscordClientOptions _options;
    private bool _disposed;

    public DiscordClient(IOptions<DiscordClientOptions> options, ILogger<DiscordClient> logger)
    {
        _options = options.Value;
        _logger = logger;
        _client = new DiscordSocketClient(new DiscordSocketConfig
        {
            LogLevel = LogSeverity.Info,
            MessageCacheSize = 100
        });

        _client.Log += LogAsync;
        _client.Ready += ReadyAsync;
    }

    public async Task StartAsync()
    {
        await _client.LoginAsync(TokenType.Bot, _options.Token);
        await _client.StartAsync();
    }

    public async Task StopAsync()
    {
        await _client.StopAsync();
        await _client.LogoutAsync();
    }

    public async Task SendMessageAsync(string message, ulong? channelId = null)
    {
        var targetChannelId = channelId ?? ulong.Parse(_options.ChannelId);
        var channel = _client.GetChannel(targetChannelId) as IMessageChannel;
        
        if (channel != null)
        {
            await channel.SendMessageAsync(message);
            _logger.LogInformation("Message sent to Discord channel {ChannelId}", targetChannelId);
        }
        else
        {
            _logger.LogWarning("Could not find Discord channel {ChannelId}", targetChannelId);
        }
    }

    public async Task SendEmbedAsync(Embed embed, ulong? channelId = null)
    {
        var targetChannelId = channelId ?? ulong.Parse(_options.ChannelId);
        var channel = _client.GetChannel(targetChannelId) as IMessageChannel;
        
        if (channel != null)
        {
            await channel.SendMessageAsync(embed: embed);
            _logger.LogInformation("Embed sent to Discord channel {ChannelId}", targetChannelId);
        }
        else
        {
            _logger.LogWarning("Could not find Discord channel {ChannelId}", targetChannelId);
        }
    }

    public EmbedBuilder CreateUpdateEmbed(string title, string description, Color? color = null)
    {
        return new EmbedBuilder()
            .WithTitle(title)
            .WithDescription(description)
            .WithColor(color ?? Color.Blue)
            .WithTimestamp(DateTimeOffset.UtcNow)
            .WithFooter("OmniUpdate");
    }

    private Task LogAsync(LogMessage log)
    {
        var logLevel = log.Severity switch
        {
            LogSeverity.Critical => LogLevel.Critical,
            LogSeverity.Error => LogLevel.Error,
            LogSeverity.Warning => LogLevel.Warning,
            LogSeverity.Info => LogLevel.Information,
            LogSeverity.Verbose => LogLevel.Debug,
            LogSeverity.Debug => LogLevel.Trace,
            _ => LogLevel.Information
        };

        _logger.Log(logLevel, log.Exception, "[Discord] {Message}", log.Message);
        return Task.CompletedTask;
    }

    private Task ReadyAsync()
    {
        _logger.LogInformation("Discord client is ready! Logged in as {Username}#{Discriminator}", 
            _client.CurrentUser.Username, _client.CurrentUser.Discriminator);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            _client?.Dispose();
            _disposed = true;
        }
    }
}
