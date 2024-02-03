using OmniUpdate.Api.Data;
using OmniUpdate.Api.Entities;

namespace OmniUpdate.Api.Repositories;

public class UserRepository : IUserRepository
{
    public readonly DapperContext _context;

    public UserRepository(DapperContext ctx)
    {
        _context = ctx;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        var users = await _context.LoadData<User, dynamic>("select * from users where id = $1", new { });
        return users;
    }


    public async Task<User?> GetUser(int id)
    {
        var user = await _context.LoadData<User, dynamic>("SELECT * FROM users WHERE id = @Id", new { Id = id });
        return user.FirstOrDefault();
    }

    public async void CreateUser(User user)
    {
        await _context.SaveData("INSERT INTO Users (Name, Archived, ImageUrl, CreateDate, UpdateDate) " +
                  "VALUES (@Name, @Archived, @ImageUrl, @CreateDate, @UpdateDate)", new User
                  {
                      Id = user.Id,
                      Name = user.Name,
                      Archived = user.Archived,
                      ImageUrl = user.ImageUrl,
                      CreateDate = DateTime.Now,
                      UpdateDate = DateTime.Now,
                  });
    }
}
