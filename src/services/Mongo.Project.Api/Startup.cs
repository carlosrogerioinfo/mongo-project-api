using Crm.Mongo.Domain.Configuration;
using Crm.Mongo.Infrastructure.Configuration;
using Crm.Mongo.Infrastructure.Contexts;
using Microsoft.Extensions.Options;
using mongo_webapi.Configurations;
using MongoDB.Driver;

namespace mongo_webapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddWebApiConfiguration();

            AddDataContextConfigurations(services);

            services.AddSwaggerConfiguration();

            services.AddDependencyInjectionConfiguration();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebApiConfiguration(true);

            app.UseSwaggerConfiguration(env);
        }

        private void AddDataContextConfigurations(IServiceCollection services)
        {
            services.AddSingleton<IMongoClient, MongoClient>(sp => new MongoClient(Configuration.GetSection("MongoConfiguration")["ConnectionString"]));
            services.AddScoped<IMongoDataContext, MongoDataContext>();
            
            services.Configure<MongoConfiguration>(Configuration.GetSection(nameof(MongoConfiguration)));
            services.AddScoped<IMongoConfiguration>(x => x.GetRequiredService<IOptions<MongoConfiguration>>().Value);
        }
    }
}
