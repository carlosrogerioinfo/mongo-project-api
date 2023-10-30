using Crm.Mongo.Domain.Configuration;
using Crm.Mongo.Domain.Entities;
using Crm.Mongo.Domain.Repositories;

namespace Crm.Mongo.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(IMongoDataContext context) : base(context)
        {
        }
    }
}
