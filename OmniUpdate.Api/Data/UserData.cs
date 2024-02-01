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


        public Task<IEnumerable<User>> GetUsers() => {
            _db.LoadData<User, dynamic>()
        }

    }
}