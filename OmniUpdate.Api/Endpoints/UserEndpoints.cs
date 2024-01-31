using System.Data;
using GameStore.Api.Repositories;
using Npgsql;
using OmniUpdate.Api.Dtos;
using OmniUpdate.Api.Entities;
using Dapper;

namespace OmniUpdate.Api.Endpoints;

public static class UserEndpoints
{
    public static RouteGroupBuilder MapUserEndpoints(this IEndpointRouteBuilder routes)
    {

        const string GetUserEndPointName = "GetUser";

        

        var group = routes.MapGroup("/user").WithParameterValidation();

        group.MapGet("/", async (ILogger<User> logger, IUserRepository repository) =>
        {
            
        await using var connection = new NpgsqlConnection("Host=localhost; Database=OmniUpdate; Username=OmniUpdate; Password=OmniUpdate");

        var users = await connection.QueryAsync<User>("select * from users");


            foreach (var user in users)
            {
                logger.LogWarning(user.Name);

            }
            return users;
        });

        group.MapGet("/{id}", (IUserRepository repository, int id) =>
        {
            User? user = repository.Get(id);
            if (user == null)
            {
                return Results.NoContent();
            }

            return Results.Ok<User>(user);
        });

        group.MapPost("/", (IUserRepository repository, CreateUserDto userDto) =>
        {
 
            Random rnd = new Random();
           
            User user = new()
            {
                Id = 212 * rnd.Next(1, 100),
                Name = userDto.Name,
                ImageUrl = userDto.ImageUrl,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
            };

            repository.Create(user);

            return Results.CreatedAtRoute(GetUserEndPointName, new { id = user.Id }, user);
        });

        group.MapPut("/{id}", (IUserRepository repository, int id, UpdateUserDto updateUserDto) =>
        {

            User? user = repository.Get(id);
            if (user == null)
            {
                return Results.NoContent();
            }

            user.ImageUrl = updateUserDto.ImageUrl;
            user.Name = updateUserDto.Name;
            user.UpdateDate = DateTime.UtcNow;

            repository.Update(user);

            return Results.NoContent();
        });

        return group;
    }
}