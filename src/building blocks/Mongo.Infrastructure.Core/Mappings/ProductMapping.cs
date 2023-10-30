using Crm.Mongo.Domain.Entities;
using MongoDB.Bson.Serialization;

namespace Crm.Mongo.Infrastructure.Mappings
{
    public class ProductMapping
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Product>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.Id);
                map.MapMember(x => x.Name).SetIsRequired(true);
                map.MapMember(x => x.Description).SetIsRequired(true);
            });
        }
    }
}
