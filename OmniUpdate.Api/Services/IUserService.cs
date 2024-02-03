using OmniUpdate.Api.Data;
using OmniUpdate.Api.Entities;

namespace GameStore.Api.Repositories;

public interface IUserService
{
    void Create(User game);
    void Delete(int id);
    User? Get(int id);
    Task<IEnumerable<User>> GetAll();
    void Update(User updatedGame);
}
