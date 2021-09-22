using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System;
using BrightPeeps.Core.Services;
using System.Threading.Tasks;

namespace BrightPeeps.DataAccess.AzureSql
{
    public class AzureSqlDataAccessService : ISqlDataAccessService
    {
        private SqlConnection Connection;

        public async Task Configure(string connectionString)
        {
            Connection = new SqlConnection(connectionString);

            await TestConnection();
            await ConfigureTablesIfNeeded();
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

        private async Task ConfigureTablesIfNeeded()
        {
            // TODO: ConfigureTables after choosing schema.
            await Task.Delay(10);
        }
    }
}