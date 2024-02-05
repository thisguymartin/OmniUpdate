using OmniUpdate.Api.Dtos;

namespace OmniUpdate.Api.Entities;

public static class EntityExtension
{
    public static UserDto AsDto(this User user)
    {
        return new UserDto(user.Id, user.Name, user.Archived, user.ImageUrl, user.CreateDate, user.UpdateDate);
    }
}