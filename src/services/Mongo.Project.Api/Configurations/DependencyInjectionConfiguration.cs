using Crm.Mongo.Domain.Repositories;
using Crm.Mongo.Infrastructure.Repositories;
using mongo_webapi.Commands.Handler;

namespace mongo_webapi.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<DefaultCommandHandler>();

            return services;
        }
    }
}
