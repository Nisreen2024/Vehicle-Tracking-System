
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using VehicleTrackingSystem.Models;

namespace VehicleTrackingSystem.Services
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoDBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoDatabase GetDatabase()
        {
            return _database;
        }
    }

}