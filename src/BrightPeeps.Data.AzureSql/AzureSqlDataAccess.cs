using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System;
using BrightPeeps.Core.Services;
using System.Threading.Tasks;
using System.Linq;

namespace BrightPeeps.Data.AzureSql
{
    public class AzureSqlDataAccessService : ISqlDataAccessService
    {
        private string ConnectionString;

        public AzureSqlDataAccessService(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public async Task ExecuteCommand<T>(string command, T parameters)
        {
            using var connection = new SqlConnection(ConnectionString);
            await connection.OpenAsync();
            await connection.ExecuteAsync(command, parameters);
        }

        public async Task<IEnumerable<TResult>> ExecuteStoredProcedure<TResult, TParam>(string procedureId, TParam parameters)
        {
            using var connection = new SqlConnection(ConnectionString);
            await connection.OpenAsync();
            return (await connection.QueryAsync<TResult>($"EXECUTE [dbo].[{procedureId}]", parameters));
        }

        public async Task<IEnumerable<TResult>> ExecuteQuery<TResult, TParam>(string query, TParam parameters)
        {
            using var connection = new SqlConnection(ConnectionString);
            await connection.OpenAsync();
            return (await connection.QueryAsync<TResult>(query, parameters));
        }

        public async Task TestConnection()
        {
            await ExecuteStoredProcedure<dynamic, dynamic>(
                procedureId: "connectionTest",
                parameters: null
            );
        }
    }
}