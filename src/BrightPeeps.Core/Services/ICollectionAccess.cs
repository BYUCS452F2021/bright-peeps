using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrightPeeps.Core.Services
{
    public interface ICollectionAccess<T>
    {
        List<T> GetAll();

        Task<List<T>> GetAllAsync();

        T Get(string id);

        Task<T> GetAsync(string id);

        void Insert(T entry);

        Task InsertAsync(T entry);

        void Update(T entry);

        Task UpdateAsync(T entry);

        void Delete(T entry);

        Task DeleteAsync(T entry);

        void Delete(string id);

        Task DeleteAsync(string id);
    }
}