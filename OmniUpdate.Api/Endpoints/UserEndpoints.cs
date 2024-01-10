using OmniUpdate.Api.Entities;

namespace OmniUpdate.Api.Endpoints;

public static class UserEndpoints
{
    public static RouteGroupBuilder MapUserEndpoints(this IEndpointRouteBuilder routes) {
        // const string GetUserEndpointName = "GetUser";

        List<User> users = new() {
            new User  {
                Name = "Martin",
                Archived = true,
                CreatedDate = new DateTime(),
                lastUpdate = new DateTime()
            }
        };

        var group = routes.MapGroup("/user");

        group.MapGet("/", () => users);

        return group;
    }
}