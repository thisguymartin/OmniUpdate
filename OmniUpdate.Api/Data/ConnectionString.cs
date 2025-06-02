namespace OmniUpdate.Api.Data;

public class ConnectionString
{
    public string? Default { get; set; }
    public string? Redis { get; set; }
    
    public static ConnectionString FromConfiguration(IConfiguration configuration)
    {
        return new ConnectionString
        {
            Default = configuration.GetConnectionString("Default"),
            Redis = configuration.GetConnectionString("Redis")
        };
    }
}