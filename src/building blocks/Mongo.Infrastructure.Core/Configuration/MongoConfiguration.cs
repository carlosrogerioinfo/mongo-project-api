using Crm.Mongo.Domain.Configuration;

namespace Crm.Mongo.Infrastructure.Configuration
{
    public class MongoConfiguration : IMongoConfiguration
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}
