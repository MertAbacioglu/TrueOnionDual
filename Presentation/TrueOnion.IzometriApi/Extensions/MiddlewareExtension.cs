using TrueOnion.PERSISTINCE.Middlewares;

namespace TrueOnion.IzometriApi.Extensions
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseApplicationMiddlewares(this IApplicationBuilder app)
        {
            IWebHostEnvironment? env = app.ApplicationServices.GetService<IWebHostEnvironment>();

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseMiddleware<CustomExceptionMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }

    }
}
