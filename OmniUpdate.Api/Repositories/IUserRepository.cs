using OmniUpdate.Api.Entities;

namespace GameStore.Api.Repositories;

public interface IUserRepository
{
    void Create(User game);
    void Delete(int id);
    User? Get(int id);
    IEnumerable<User> GetAll();
    void Update(User updatedGame);
}
