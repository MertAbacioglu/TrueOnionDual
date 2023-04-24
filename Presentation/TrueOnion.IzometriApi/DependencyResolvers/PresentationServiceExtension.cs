using FluentValidation;
using FluentValidation.AspNetCore;
using System.Text.Json;
using TrueOnion.APPLICATION.Validators;
using TrueOnion.PERSISTINCE.Settings;

namespace TrueOnion.IzometriApi.DependencyResolvers
{
    public static class PresentationServiceExtension
    {
        public static void AddPresentationInjections(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddValidatorsFromAssemblyContaining<UserCreateDTOValidator>();
            services.AddFluentValidationAutoValidation();

            services.AddValidatorsFromAssemblyContaining<DepartmentCreateDTOValidator>();

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.WriteIndented = true;
            });
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();

            services.Configure<MongoSetting>(configuration.GetSection("MongoSetting"));

        }
    }
}
