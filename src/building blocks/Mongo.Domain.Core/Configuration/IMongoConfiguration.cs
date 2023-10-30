namespace Crm.Mongo.Domain.Configuration
{
    public interface IMongoConfiguration
    {
        string DatabaseName { get; set; }

        string ConnectionString { get; set; }
    }
}
