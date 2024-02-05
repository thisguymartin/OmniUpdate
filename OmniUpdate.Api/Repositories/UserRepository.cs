using OmniUpdate.Api.Data;
using OmniUpdate.Api.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OmniUpdate.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _context;

        public UserRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.LoadData<User, dynamic>("SELECT * FROM users", new { });
            return users;
        }

        public async Task<User?> GetUser(int id)
        {
            var users = await _context.LoadData<User, dynamic>("SELECT * FROM users WHERE id = @Id", new { Id = id });
            return users.FirstOrDefault();
        }

        public async Task CreateUser(User user)
        {
            await _context.SaveData("INSERT INTO users (Name, Archived, ImageUrl, CreateDate, UpdateDate) VALUES (@Name, @Archived, @ImageUrl, @CreateDate, @UpdateDate)", user);
        }

        public async Task UpdateUser(User user)
        {
            await _context.SaveData("UPDATE users SET Name = @Name, Archived = @Archived, ImageUrl = @ImageUrl, CreateDate = @CreateDate, UpdateDate = @UpdateDate WHERE Id = @Id", user);
        }

        public async Task DeleteUser(int id)
        {
            await _context.SaveData("DELETE FROM users WHERE Id = @Id", new { Id = id });
        }
    }
}
