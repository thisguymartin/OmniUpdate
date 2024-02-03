using OmniUpdate.Api.Entities;

namespace OmniUpdate.Api.Data;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsers();
    Task<User?> GetUser(int id);
    void CreateUser(User user);
}
