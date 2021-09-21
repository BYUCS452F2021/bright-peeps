using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System;
using BrightPeeps.Core.Services;
using System.Threading.Tasks;

namespace BrightPeeps.DataAccess.SqlServer
{
    public class SqlServerDataAccessService : ISqlDataAccessService
    {
        private SqlConnection Connection;

        public async Task Configure(string connectionString)
        {
            Connection = new System.Data.SqlClient.SqlConnection(connectionString);

            await TestConnection();
            await ConfigureTablesIfNeeded();
        }

        ~SqlServerDataAccessService()
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
            try
            {
                var result = Connection.Query("SELECT @@version AS version;");
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
            }

            return Task.CompletedTask;
        }

        private async Task ConfigureTablesIfNeeded()
        {
            // TODO: ConfigureTables after choosing schema.
            await Task.Delay(10);
        }
    }
}