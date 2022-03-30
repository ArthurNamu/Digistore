using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.DB
{
    public class SQLAccess : IDataAccess
    {

        private readonly IConfiguration _config;
        public SQLAccess(IConfiguration config)
        {
            _config = config;
        }
        public async Task<List<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters, string connectionStringName)
        {
            using (IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionStringName)))
            {
                var rows = await connection.QueryAsync<T>(storedProcedure,
                                                                                    parameters,
                                                                                    commandType: CommandType.StoredProcedure);
                return rows.ToList();
            }
        }

       public async Task<T> LoadSingleRowAsync<T, U>(string storedProcedure, U parameters, string connectionStringName)
        {
            using (IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionStringName)))
            {
                var rows = await connection.QueryAsync<T>(storedProcedure,
                                                                                     parameters,
                                                                                     commandType: CommandType.StoredProcedure);
                return rows.FirstOrDefault();
            }
        }
        public async Task<T> ExecuteFunctionAsync<T, U>(string storedProcedure, U parameters, string connectionStringName)
        {
            using (IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionStringName)))
            {
                var rows = await connection.QueryAsync<T>(storedProcedure,
                                                                                     parameters,
                                                                                     commandType: CommandType.Text);
                return rows.FirstOrDefault();
            }
        }

        public async Task<T> GetSingleValueAsync<T, U>(string storedProcedure, U parameters, string connectionStringName)
        {
            using (IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionStringName)))
            {
                var val = await connection.ExecuteScalarAsync<T>(storedProcedure,
                                                                                    parameters,
                                                                                    commandType: CommandType.StoredProcedure);
                return val;
            }
        }
        public  bool GetSingleValue<T, U>(string storedProcedure, U parameters, string connectionStringName)
        {
            using (IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionStringName)))
            {
                var val =  connection.ExecuteScalar<bool>(storedProcedure,
                                                                                    parameters,
                                                                                    commandType: CommandType.StoredProcedure);
                return val;
            }
        }

        public async Task SaveDataAsync<T>(string storedProcedure, T parameters, string connectionStringName)
        {
            using (IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionStringName)))
            {
                //try
                //{
                await connection.ExecuteAsync(storedProcedure, parameters,
                     commandType: CommandType.StoredProcedure);
                //}
                //catch (Exception e)
                //{

                //    Console.WriteLine(e.Message);
                //}
               
            }
        }
    }
}
