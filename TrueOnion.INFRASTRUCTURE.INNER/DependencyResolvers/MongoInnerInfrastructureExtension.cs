using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueOnion.APPLICATION.Repositories;
using TrueOnion.APPLICATION.Services;
using TrueOnion.INFRASTRUCTURE.INNER.Services;
using TrueOnion.PERSISTINCE.Repositories.Mongo;
using TrueOnion.PERSISTINCE.Settings;

namespace TrueOnion.INFRASTRUCTURE.INNER.DependencyResolvers
{
    public static class MongoInnerInfrastructureExtension
    {
        public static IServiceCollection AddInfrastructureMongo(this IServiceCollection services, IConfiguration configuration)
        {
            configuration.GetSection("MongoSetting");

            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            
            services.AddSingleton<MongoSetting>(sp =>
            {
                return sp.GetRequiredService<IOptions<MongoSetting>>().Value;
            });


            return services;
        }
    }
}