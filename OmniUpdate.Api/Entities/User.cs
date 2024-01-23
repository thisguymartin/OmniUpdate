namespace OmniUpdate.Api.Entities;

public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }

}