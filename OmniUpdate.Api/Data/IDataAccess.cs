using System.Collections.Generic;
using System.Threading.Tasks;

public interface IDataAccess
{
    Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "Default");
    Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "Default");
}