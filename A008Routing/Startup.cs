using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace A008Routing
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.Use(async (context, next) =>
            {
                // получаем конечную точку
                Endpoint endpoint = context.GetEndpoint();

                if (endpoint != null)
                {
                    // получаем шаблон маршрута, который ассоциирован с конечной точкой
                    var routePattern = (endpoint as Microsoft.AspNetCore.Routing.RouteEndpoint)?.RoutePattern?.RawText;

                    Debug.WriteLine($"Endpoint Name: {endpoint.DisplayName}");
                    Debug.WriteLine($"Route Pattern: {routePattern}");

                    // если конечная точка определена, передаем обработку дальше
                    await next();
                }
                else
                {
                    Debug.WriteLine("Endpoint: null");
                    // если конечная точка не определена, завершаем обработку
                    await context.Response.WriteAsync("Endpoint is not defined");
                }
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/index", async context =>
                {
                    await context.Response.WriteAsync("Hello Index!");
                });

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
