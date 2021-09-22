using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System;
using BrightPeeps.Core.Services;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BrightPeeps.DataAccess.MySql
{
    public class MySqlDataAccessService : ISqlDataAccessService
    {
        private MySqlConnection Connection;

        public async Task Configure(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);

            await TestConnection();
            await ConfigureTablesIfNeeded();
        }

        ~MySqlDataAccessService()
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

        private Task TestConnection()
        {
            var result = Connection.Query("CALL `connection-test`");
            return Task.CompletedTask;
        }

        private async Task ConfigureTablesIfNeeded()
        {
            // TODO: ConfigureTables after choosing schema.
            await Task.Delay(10);
        }
    }
}