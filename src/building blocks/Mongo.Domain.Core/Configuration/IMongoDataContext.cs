using MongoDB.Driver;

namespace Crm.Mongo.Domain.Configuration
{
    public interface IMongoDataContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
