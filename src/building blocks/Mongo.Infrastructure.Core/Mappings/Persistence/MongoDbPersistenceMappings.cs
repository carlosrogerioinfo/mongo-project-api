using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;

namespace Crm.Mongo.Infrastructure.Mappings.Persistence
{
    public static class MongoDbPersistenceMappings
    {
        public static void Configure()
        {
            ProductMapping.Configure();

            //BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;
            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.CSharpLegacy));

            // Conventions
            var pack = new ConventionPack
                {
                    new IgnoreExtraElementsConvention(true),
                    new IgnoreIfDefaultConvention(true)
                };
            ConventionRegistry.Register("Convenções da aplicação", pack, t => true);
        }
    }
}
