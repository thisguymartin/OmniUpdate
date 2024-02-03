using GameStore.Api.Repositories;
using OmniUpdate.Api.Data;
using OmniUpdate.Api.Entities;

namespace OmniUpdate.Api.Repositories;

public class UserService : IUserService
{
private readonly List<User> users = new()
{
    new User()
    {
        Id = 1,
        Name = "John Doe",
        Archived = false,
        ImageUrl = "https://example.com/image1.jpg",
        CreateDate = DateTime.Now,
        UpdateDate = DateTime.Now
    },
    new User()
    {
        Id = 2,
        Name = "Jane Smith",
        Archived = false,
        ImageUrl = "https://example.com/image2.jpg",
        CreateDate = DateTime.Now,
        UpdateDate = DateTime.Now
    },
    new User()
    {
        Id = 3,
        Name = "Alice Johnson",
        Archived = true, // Example of an archived user
        ImageUrl = "https://example.com/image3.jpg",
        CreateDate = DateTime.Now.AddDays(-30), // Example with different dates
        UpdateDate = DateTime.Now.AddDays(-1)
    }
};

    public async Task<IEnumerable<User>> GetAll(IUserRepository userRepository)
    {
        IEnumerable<User> users = await userRepository.GetUsers();
        return users;
    }

    public async Task<User?> Get(int id)
    {
        return users.Find(game => game.Id == id);
    }

    public Task Create(User game)
    {
        game.Id = users.Max(game => game.Id) + 1;
        users.Add(game);
        return Task.CompletedTask;
    }

    public Task Update(User updatedGame)
    {
        var index = users.FindIndex(game => game.Id == updatedGame.Id);
        users[index] = updatedGame;
        return Task.CompletedTask;
    }

    public Task Delete(int id)
    {
        var index = users.FindIndex(game => game.Id == id);
        users.RemoveAt(index);
        return Task.CompletedTask;
    }
}