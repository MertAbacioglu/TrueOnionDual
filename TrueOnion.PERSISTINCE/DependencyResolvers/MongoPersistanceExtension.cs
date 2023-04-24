using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrueOnion.APPLICATION.Repositories;
using TrueOnion.PERSISTINCE.Context;
using TrueOnion.PERSISTINCE.Repositories.Mongo;

namespace TrueOnion.PERSISTINCE.DependencyResolvers
{
    public static class MongoPersistanceExtension
    {
        public static IServiceCollection AddPersistanceMongo(this IServiceCollection services)
        {
            services.AddScoped<IMongoDbContext, MongoDbContext>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(MongoGenericRepository<>));
            services.AddScoped<IUserRepository, MongoUserRepository>();
            services.AddScoped<IDepartmentRepository, MongoDepartmentRepository>();

            return services;
        }

    }
}
