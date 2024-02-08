using OmniUpdate.Api.Models.Entities;
using OmniUpdate.Api.Repositories;

namespace OmniUpdate.Api.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _userRepository.GetUsers();
    }

    public async Task<User?> Get(int id)
    {
        return await _userRepository.GetUser(id);
    }

    public async Task Create(User user)
    {
        await _userRepository.CreateUser(user);
    }

    public async Task Update(User user)
    {
        await _userRepository.UpdateUser(user);
    }

    public async Task Delete(int id)
    {
        await _userRepository.DeleteUser(id);
    }
}
