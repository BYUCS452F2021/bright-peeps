using System.Collections.Generic;
using System.Threading.Tasks;
using BrightPeeps.Core.Services;
using BrightPeeps.Data.MongoDB.Models;
using MongoDB.Driver;

namespace BrightPeeps.Data.MongoDB
{
    public class MongoDBCollectionAccess<T> : ICollectionAccess<T> where T : Entry
    {
        public readonly IMongoCollection<T> Collection;

        public MongoDBCollectionAccess(IMongoCollection<T> collection)
        {
            Collection = collection;
        }

        public List<T> GetAll() => Collection.Find(entry => true).ToList();

        public Task<List<T>> GetAllAsync() => Task.FromResult(GetAll());

        public T Get(string id) => Collection.Find(entry => entry.Id.Equals(id)).FirstOrDefault();

        public Task<T> GetAsync(string id) => Collection.Find(entry => entry.Id.Equals(id)).FirstOrDefaultAsync();

        public void Insert(T entry) => Collection.InsertOne(entry);

        public Task InsertAsync(T entry) => Collection.InsertOneAsync(entry);

        public void Update(T entry) => Collection.ReplaceOne(p => p.Id.Equals(entry.Id), entry);

        public Task UpdateAsync(T entry) => Collection.ReplaceOneAsync(p => p.Id.Equals(entry.Id), entry);

        public void Delete(T entry) => Collection.DeleteOne(p => p.Id.Equals(entry.Id));

        public Task DeleteAsync(T entry) => Collection.DeleteOneAsync(p => p.Id.Equals(entry.Id));

        public void Delete(string id) => Collection.DeleteOne(p => p.Id.Equals(id));

        public Task DeleteAsync(string id) => Collection.DeleteOneAsync(p => p.Id.Equals(id));
    }
}