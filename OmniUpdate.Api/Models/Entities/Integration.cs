namespace OmniUpdate.Api.Models.Entities;

public class Integration
{
    public int IntegrationId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    // Navigation property for user integrations
    public ICollection<UserIntegration> UserIntegrations { get; set; }
}
