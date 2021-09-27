using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrightPeeps.Core.Services
{
    public interface ISqlDataAccessService
    {
        Task<IEnumerable<TResult>> ExecuteStoredProcedure<TResult, TParam>(string procedureId, TParam parameters);
        Task ExecuteCommand<T>(string command, T parameters);
        Task<IEnumerable<TResult>> ExecuteQuery<TResult, TParam>(string query, TParam parameters);
        Task TestConnection();
    }
}