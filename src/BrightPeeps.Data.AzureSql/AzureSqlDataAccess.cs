using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System;
using BrightPeeps.Core.Services;
using System.Threading.Tasks;

namespace BrightPeeps.Data.AzureSql
{
    public class AzureSqlDataAccessService : ISqlDataAccessService
    {
        private SqlConnection Connection;

        public AzureSqlDataAccessService(string connectionString)
        {
            Connection = new SqlConnection(connectionString);

            Task.Run(() => TestConnection());
        }

        ~AzureSqlDataAccessService()
        {
            Connection.Dispose();
        }

        public async Task ExecuteCommand<T>(string command, T parameters)
        {
            await Connection.ExecuteAsync(command, parameters);
        }

        public Task<IEnumerable<T>> ExecuteQuery<T, TParam>(string query, TParam parameters)
        {
            return Connection.QueryAsync<T>(query, parameters);
        }

        private async Task TestConnection()
        {
            var result = await Connection.QueryAsync("EXEC [dbo].[connection-test]");
        }
    }
}