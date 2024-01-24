using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Api.Repositories;
using OmniUpdate.Api.Entities;

namespace OmniUpdate.Api.Endpoints;

public static class UserEndpoints
{
    public static RouteGroupBuilder MapUserEndpoints(this IEndpointRouteBuilder routes)
    {

        List<User> users = new() { };

        const string GetUserEndPointName = "GetUser";

        var group = routes.MapGroup("/user");

        group.MapGet("/", (IUserRepository repository) => repository.GetAll());

        group.MapGet("/{id}", (int id) =>
        {
            User? user = users.Find(e => e.Id == id);
            if (user == null)
            {
                return Results.NoContent();
            }

            return Results.Ok<User>(user);
        });

        group.MapPost("/", (User user) =>
        {
            user.Id = users.Max(user => user.Id) + 1;
            users.Add(user);
            return Results.CreatedAtRoute(GetUserEndPointName, new { id = user.Id }, user);
        });

        group.MapPut("/{id}", (int id, User userInput) =>
        {
            User? user = users.Find(e => e.Id == id);
            if (user == null)
            {
                return Results.NoContent();
            }

            user.ImageUrl = userInput.ImageUrl;
            user.Name = userInput.Name;
            user.UpdateDate = DateTime.UtcNow;
            return Results.NoContent();
        });

        return group;
    }
}