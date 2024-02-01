using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OmniUpdate.Api.Entities;

namespace OmniUpdate.Api.Data
{
    public class UserData
    {
        public readonly IDataAccess _db;

        public UserData(IDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<User>> GetUsers() =>
            _db.LoadData<User, dynamic>("select * from users where id = $1", new { });

        public async Task<User?> GetUser(int id)
        {
            var user = await _db.LoadData<User, dynamic>("SELECT * FROM users WHERE id = @Id", new { Id = id });
            return user.FirstOrDefault();
        }

    }
}