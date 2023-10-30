using MongoDB.Bson;

namespace Crm.Mongo.Domain.Entities
{
    public class Product
    {
        public Product(string description, string name)
        {
            Description = description;
            Name = name;
            Id = ObjectId.GenerateNewId();
        }

        public Product(ObjectId id, string description, string name)
        {
            Id = id;
            Description = description;
            Name = name;
        }

        public ObjectId Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}
