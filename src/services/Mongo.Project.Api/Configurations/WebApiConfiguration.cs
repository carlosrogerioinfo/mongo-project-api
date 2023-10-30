﻿using Crm.Mongo.Infrastructure.Mappings.Persistence;
using System.Text.Json.Serialization;

namespace mongo_webapi.Configurations
{
    public static class WebApiConfiguration
    {

        public static IServiceCollection AddWebApiConfiguration(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddControllers()
            .AddJsonOptions(options => { options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; });

            MongoDbPersistenceMappings.Configure();

            return services;
        }

        public static IApplicationBuilder UseWebApiConfiguration(this IApplicationBuilder app, bool useCors = false)
        {
            app.UseRouting();

            if (useCors)
            {
                app.UseCors(x => x
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            }

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }

    }
}
