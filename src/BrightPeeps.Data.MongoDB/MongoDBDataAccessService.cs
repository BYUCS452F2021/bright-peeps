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

            Users = new MongoDBCollectionAccess<UserData>(
                collection: database.GetCollection<UserData>("users")
            );

            Peeps = new MongoDBCollectionAccess<PeepData>(
                collection: database.GetCollection<PeepData>("peeps")
            );

            Images = new MongoDBCollectionAccess<ImageData>(
                collection: database.GetCollection<ImageData>("images")
            );

            Works = new MongoDBCollectionAccess<WorkData>(
                collection: database.GetCollection<WorkData>("works")
            );
        }
    }
}