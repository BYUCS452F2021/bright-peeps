using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System;
using BrightPeeps.Core.Services;
using System.Threading.Tasks;
using System.Linq;
using System.Reflection;
using System.Text;
using BrightPeeps.Core.Utils;

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

        public async Task<IEnumerable<TResult>> ExecuteStoredProcedure<TResult>(string procedureId)
        {
            using var connection = new SqlConnection(ConnectionString);
            await connection.OpenAsync();

            return await connection.QueryAsync<TResult>($"[dbo].[{procedureId}]");
        }

        public async Task<IEnumerable<TResult>> ExecuteStoredProcedure<TResult, TParam>(string procedureId, TParam parameters)
        {
            using var connection = new SqlConnection(ConnectionString);
            await connection.OpenAsync();

            return await connection.QueryAsync<TResult>(
                sql: $"[dbo].[{procedureId}] {GetParameterNames<TParam>(parameters)}",
                param: parameters
            );
        }

        public static string GetParameterNames<T>(T parameters)
        {
            var properties = new List<PropertyInfo>(typeof(T).GetProperties());

            var buffer = new StringBuilder();

            properties.ForEach(property => buffer.Append($"@{property.Name},"));

            buffer.Remove(buffer.Length - 1, 1); // Removes trailing comma.

            return buffer.ToString();
        }

        public async Task<IEnumerable<TResult>> ExecuteQuery<TResult, TParam>(string query, TParam parameters)
        {
            using var connection = new SqlConnection(ConnectionString);
            await connection.OpenAsync();
            return (await connection.QueryAsync<TResult>(query, parameters));
        }

        public async Task TestConnection()
        {
            await ExecuteStoredProcedure<dynamic>(
                procedureId: "ConnectionTest"
            );
        }
    }
}