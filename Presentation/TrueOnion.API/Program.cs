using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using TrueOnion.APPLICATION.DependencyResolvers;
using TrueOnion.APPLICATION.Mapping;
using TrueOnion.INFRASTRUCTURE.INNER.DependencyResolvers.Autofac;
using TrueOnion.PERSISTINCE.Context;
using TrueOnion.PERSISTINCE.DependencyResolvers.Autofac;
using TrueOnion.PERSISTINCE.Repositories.EntityFramework;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;

});

// Add services to the container.

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureServices(x => x.AddAutofac()).UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacPersistanceModule());
    builder.RegisterModule(new AutofacInnerInfrastructureModule());
});
builder.Services.AddApplicationLayerInjections();


// Diğer servislerin kaydını da burada yapabilirsiniz


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();



app.MapControllers();

app.Run();

