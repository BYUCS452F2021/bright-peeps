using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrightPeeps.Core.Services
{
    public interface ISqlDataAccessService
    {
        Task Configure(string connectionString);
        Task ExecuteCommand<T>(string command, T parameters);
        Task<IEnumerable<T>> ExecuteQuery<T, TParam>(string query, TParam parameters);
    }
}