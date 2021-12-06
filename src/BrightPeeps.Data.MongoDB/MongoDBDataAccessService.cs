using BrightPeeps.Core.Services;
using BrightPeeps.Data.MongoDB.Models;
using MongoDB.Driver;

namespace BrightPeeps.Data.MongoDB
{
    public class MongoDBDataAccessService
    {
        public readonly MongoDBCollectionAccess<UserData> Users;
        public readonly MongoDBCollectionAccess<PeepData> Peeps;
        public readonly MongoDBCollectionAccess<ImageData> Images;
        public readonly MongoDBCollectionAccess<WorkData> Works;

        public MongoDBDataAccessService(string connectionString)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("bright-peeps");
        }
    }
}