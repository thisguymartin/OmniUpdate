using OmniUpdate.Api.Entities;

namespace OmniUpdate.Api.Data;

public interface IUserData
{
    Task<IEnumerable<User>> GetUsers();
    Task<User?> GetUser(int id);
}
