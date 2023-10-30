namespace Crm.Mongo.Domain.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T obj);
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        void Update(T obj);
        void Remove(Guid id);
    }
}
