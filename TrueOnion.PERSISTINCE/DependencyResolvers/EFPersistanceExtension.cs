using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Reflection;
using TrueOnion.APPLICATION.Repositories;
using TrueOnion.PERSISTINCE.Context;
using TrueOnion.PERSISTINCE.Repositories.EntityFramework;
using TrueOnion.PERSISTINCE.Settings;
using Module = Autofac.Module;
using Microsoft.Extensions.DependencyInjection;
using Autofac.Core;
using TrueOnion.APPLICATION.UnitOfWork;
using TrueOnion.PERSISTINCE.UnitOfWork;

namespace TrueOnion.PERSISTINCE.DependencyResolvers
{
    public static class EFPersistanceExtension
    {
        public static IServiceCollection AddPersistanceEf(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(EfGenericRepository<>));

            services.AddScoped<IDepartmentRepository, EfDepartmentRepository>();
            services.AddScoped<IUserRepository, EfUserRepository>();
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();

            services.AddDbContext<EFDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
            
            //ServiceProvider serviceProvider = services.BuildServiceProvider();
            //EFDbContext? dbContext = serviceProvider.GetService<EFDbContext>();

            //if (!dbContext.Database.EnsureCreated())
            //{
            //    dbContext.Database.Migrate();
            //}
            return services;
        }

    }




}
