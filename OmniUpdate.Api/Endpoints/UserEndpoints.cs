using Microsoft.Extensions.Options;
using OmniUpdate.Api.Data;
using OmniUpdate.Api.Dtos;
using OmniUpdate.Api.Entities;
using OmniUpdate.Api.Models.Entities;
using OmniUpdate.Api.Services;

namespace OmniUpdate.Api.Endpoints;

public static class UserEndpoints
{

    public static RouteGroupBuilder MapUserEndpoints(this IEndpointRouteBuilder routes)
    {
        const string GetUserEndPointName = "GetUser";

        var group = routes.MapGroup("/users").WithParameterValidation();

        group.MapGet("/", async (ILogger<User> _logger, IUserService userService) =>
        {
            _logger.LogDebug("Getting Users");
            var users = await userService.GetAll();
            _logger.LogDebug("Got Users", users);
            return users;
        });

        group.MapGet("/{id}", async (ILogger<User> _logger, int id, IUserService userService) =>
        {
            User? user = await userService.Get(id);
            if (user == null)
            {
                return Results.NoContent();
            }
            _logger.LogInformation("Got User", user);
            return Results.Ok(user);
        });

        group.MapPost("/", async (CreateUserDto userDto, IUserService userService) =>
        {
            User user = new()
            {
                Id = 3,
                Name = userDto.Name,
                ImageUrl = userDto.ImageUrl,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
            };

            await userService.Create(user);

            return Results.CreatedAtRoute(GetUserEndPointName, new { id = user.Id }, user);
        });

        group.MapPut("/{id}", async (int id, UpdateUserDto updateUserDto, IUserService userService) =>
        {
            User? user = await userService.Get(id);
            if (user == null)
            {
                return Results.NoContent();
            }

            user.ImageUrl = updateUserDto.ImageUrl;
            user.Name = updateUserDto.Name;
            user.UpdateDate = DateTime.UtcNow;

            await userService.Update(user);

            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (int id, IUserService userService) =>
        {
            await userService.Delete(id);
            return Results.NoContent();
        });

        return group;
    }
}
