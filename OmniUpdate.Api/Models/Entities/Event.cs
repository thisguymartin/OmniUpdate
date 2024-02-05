using OmniUpdate.Api.Entities;

namespace OmniUpdate.Api.Models.Entities
{
    public class Event
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation property
        public User User { get; set; }
        public required ICollection<EventIntegration> EventIntegrations { get; set; }
    }
}