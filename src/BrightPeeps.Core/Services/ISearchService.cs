using System.Collections.Generic;
using System.Threading.Tasks;
using BrightPeeps.Core.Models;

namespace BrightPeeps.Core.Services
{
    public interface ISearchService<T>
    {
        void AddOne(T item);
        Task AddOneAsync(T item);
        void AddMany(IEnumerable<T> items);
        Task AddManyAsync(IEnumerable<T> items);
        void DeleteAll();
        Task DeleteAllAsync();
        void DeleteOne(string itemId);
        Task DeleteOneAsync(string itemId);
        void Update(T item);
        Task UpdateAsync(T item);
        IEnumerable<SearchResultData> Search(string queryString, int maxResultsCount);
        Task<IEnumerable<SearchResultData>> SearchAsync(string queryString,
            int maxResultsCount);
    }
}