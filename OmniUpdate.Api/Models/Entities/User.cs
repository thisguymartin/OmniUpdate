using System.ComponentModel.DataAnnotations;

namespace OmniUpdate.Api.Models.Entities;

public class User
{
    public required int Id { get; set; }
    [Required]
    [StringLength(50)]
    public required string Name { get; set; }
    public bool Archived { get; set; }
    [Url]
    public string? ImageUrl { get; set; }
    [Timestamp]
    public DateTime CreateDate { get; set; }
    [Timestamp]
    public DateTime UpdateDate { get; set; }
}
