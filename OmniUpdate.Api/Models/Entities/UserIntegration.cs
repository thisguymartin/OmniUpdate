namespace OmniUpdate.Api.Models.Entities
{

    public class UserIntegration
    {
        public int UserIntegrationId { get; set; }
        public int UserId { get; set; }
        public int IntegrationId { get; set; }
        public required string Credentials { get; set; }
        public required string Settings { get; set; }
        public DateTime CreatedAt { get; set; }
        public required User User { get; set; }
        public required Integration Integration { get; set; }
    }

}