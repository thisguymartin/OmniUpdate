using OmniUpdate.Api.Data;
using OmniUpdate.Api.Models.Entities;

namespace OmniUpdate.Api.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User?> Get(int id);
        Task Create(User user);
        Task Update(User user);
        Task Delete(int id);
    }
}
