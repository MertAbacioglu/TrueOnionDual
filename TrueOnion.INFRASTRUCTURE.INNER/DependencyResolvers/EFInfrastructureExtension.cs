using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrueOnion.APPLICATION.Repositories;
using TrueOnion.APPLICATION.Services;
using TrueOnion.INFRASTRUCTURE.INNER.Services;
using TrueOnion.PERSISTINCE.Repositories.EntityFramework;

namespace TrueOnion.INFRASTRUCTURE.INNER.DependencyResolvers
{
    public static class EFInfrastructureExtension
    {
        public static IServiceCollection AddInfrastructureEF(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
    
}
