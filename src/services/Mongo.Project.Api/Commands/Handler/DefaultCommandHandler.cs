using Crm.Mongo.Domain.Entities;
using Crm.Mongo.Domain.Repositories;

namespace mongo_webapi.Commands.Handler
{
    public class DefaultCommandHandler
    {
        private readonly IProductRepository _productRepository;

        public DefaultCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle()
        {
            var commandObject = await _productRepository.GetAll();

            return commandObject;
        }
    }
}
