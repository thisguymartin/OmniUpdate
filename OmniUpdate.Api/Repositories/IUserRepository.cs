using OmniUpdate.Api.Entities;
using OmniUpdate.Api.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OmniUpdate.Api.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User?> GetUser(int id);
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int id);
    }
}
