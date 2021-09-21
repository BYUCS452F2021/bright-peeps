using System.Collections.Generic;
using System.Threading.Tasks;
using BrightPeeps.Core.Models;

namespace BrightPeeps.Core.Services
{
    public interface IDaoService<T>
    {
        Task<IEnumerable<T>> All();
        Task<T> Search(string query);
        Task<T> Insert(T item);
        Task<T> GetOne(string itemId);
        Task<T> Update(T item);
        Task Delete(string itemId);
    }
}