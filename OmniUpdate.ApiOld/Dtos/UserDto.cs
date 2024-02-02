using System.ComponentModel.DataAnnotations;

namespace OmniUpdate.Api.Dtos;


public record UserDto(
    int Id,
   [Required][StringLength(50)] string Name,
    bool Archived,
   [Url] string? ImageUrl,
    DateTime CreateDate,
    DateTime UpdateDate
);

public record CreateUserDto(
   [Required][StringLength(50)] string Name,
    bool Archived,
   [Url] string? ImageUrl);

public record UpdateUserDto(
    string Name,
    bool Archived,
   [Url] string? ImageUrl);

