using TrueOnion.PERSISTINCE.DependencyResolvers;
using TrueOnion.INFRASTRUCTURE.INNER.DependencyResolvers;
using TrueOnion.PERSISTINCE.Middlewares;
using TrueOnion.IzometriApi.DependencyResolvers;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentationInjections(builder.Configuration);

if (builder.Configuration.GetValue<bool>("UseMongoDb"))
{
    builder.Services.AddPersistanceMongo();
    builder.Services.AddInfrastructureMongo(builder.Configuration);
}
else
{
    builder.Services.AddPersistanceEf(builder.Configuration);
    builder.Services.AddInfrastructureEF();


}

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<CustomExceptionMiddleware>();
app.MapControllers();
app.Run();
