using System;
using System.Data;
using Dapper;
using Npgsql;

namespace OmniUpdate.Api.Data;

public class DataAccess: IDataAccess
{
    private readonly IConfiguration _config;

    public DataAccess(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters,
                                                     string connectionId = "Default")
    {
        using IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString(connectionId));
        return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task SaveData<T>(string storedProcedure, T parameters,
                                                     string connectionId = "Default")
    {
       using IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString(connectionId));
        await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

}