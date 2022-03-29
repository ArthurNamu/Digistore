//using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataLibrary.DB
{
    public interface IDataAccess
    {
        Task<T> ExecuteFunctionAsync<T, U>(string storedProcedure, U parameters, string connectionStringName);
        Task<T> GetSingleValueAsync<T, U>(string storedProcedure, U parameters, string connectionStringName);
        bool GetSingleValue<T, U>(string storedProcedure, U parameters, string connectionStringName);
        Task<List<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters, string connectionStringName);
        Task<T> LoadSingleRowAsync<T, U>(string storedProcedure, U parameters, string connectionStringName);
        Task SaveDataAsync<T>(string storedProcedure, T parameters, string connectionStringName);
    }
}