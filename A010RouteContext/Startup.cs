using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A010RouteContext
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RouteOptions>(options =>
               options.ConstraintMap.Add("position", typeof(PositionConstraint)));

            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            //var myRouteHandler = new RouteHandler(Handle);

            var myRouteHandler = new RouteHandler(HandleAsync);

            var routeBuilder = new RouteBuilder(app, myRouteHandler);
            //routeBuilder.MapRoute("default", "{action=Index}/{name}-{year}");

            //routeBuilder.MapRoute("default2", "{controller}/{action}/{id?}");

            //***********************
            //routeBuilder.MapRoute("default",
            //    "{controller}/{action}/{id?}",
            //    new { action = "Index" }, // параметры по умолчанию
            //    new { controller = "^H.*" }, // ограничения
            //    new { controller = "^Q.*", id = @"\d{2}" }

            //********************

            //routeBuilder.MapRoute("default",
            //                        "{controller}/{action}/{id?}",
            //        null,
            //        new { controller = new RegexRouteConstraint("^H.*"), id = new RegexRouteConstraint(@"\d{2}") }

            //        );

            //***************************

            //routeBuilder.MapRoute(
            //"default",
            //"{controller}/{action}/{id}",
            //new { controller = "Home", action = "Index" },
            //new { id = new PositionConstraint() });

            //*************************** Создание inline-ограничений
            routeBuilder.MapRoute(
               "default",
               "{controller}/{action}/{id:position?}");
         

            app.UseRouter(routeBuilder.Build());

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });

        }

        private async Task HandleAsync(HttpContext context)
        {
            var routeValues = context.GetRouteData().Values;
            var action = routeValues["action"].ToString();
            var controller = routeValues["controller"].ToString();
            string id = routeValues["id"]?.ToString();
            await context.Response.WriteAsync($"controller: {controller} | action: {action} | id: {id}");
        }



        private async Task Handle(HttpContext context)
        {
            var routeValues = context.GetRouteData().Values;
            var action = routeValues["action"].ToString();
            var name = routeValues["name"].ToString();
            var year = routeValues["year"].ToString();
            await context.Response.WriteAsync($"action: {action} | name: {name} | year:{year}");
        }
    }
}
