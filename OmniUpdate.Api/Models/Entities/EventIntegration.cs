namespace OmniUpdate.Api.Models.Entities;

public class EventIntegration
{
    public int EventIntegrationId { get; set; }
    public int EventId { get; set; }
    public int UserIntegrationId { get; set; }
    public required string Status { get; set; }
    public DateTime PublishedAt { get; set; }

    // Navigation properties
    public required Event Event { get; set; }
    public required UserIntegration UserIntegration { get; set; }
}