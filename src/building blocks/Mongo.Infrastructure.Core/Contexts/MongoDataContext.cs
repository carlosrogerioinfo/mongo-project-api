using Crm.Mongo.Domain.Configuration;
using MongoDB.Driver;

namespace Crm.Mongo.Infrastructure.Contexts
{
    public class MongoDataContext : IMongoDataContext
    {
        private IMongoDatabase _database { get; set; }

        public MongoDataContext(IMongoClient mongoClient, IMongoConfiguration configuration)
        {
            _database = mongoClient.GetDatabase(configuration.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }
    }
}
