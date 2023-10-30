using Crm.Mongo.Domain.Configuration;
using Crm.Mongo.Domain.Repositories;
using MongoDB.Driver;
using ServiceStack;

namespace Crm.Mongo.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected IMongoCollection<T> DbSet;

        protected GenericRepository(IMongoDataContext context)
        {
            DbSet = context.GetCollection<T>(typeof(T).Name.ToLower());
        }

        public void Add(T obj)
        {
            DbSet.InsertOneAsync(obj);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var collection = await DbSet.FindAsync(Builders<T>.Filter.Empty);
            return collection.ToList();
        }

        public async Task<T> GetById(Guid id)
        {
            var data = await DbSet.FindAsync(Builders<T>.Filter.Eq("_id", id));
            return data.SingleOrDefault();
        }

        public void Update(T obj)
        {
            DbSet.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", obj.GetId()), obj);
        }

        public void Remove(Guid id)
        {
            DbSet.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id));
        }
    }
}
