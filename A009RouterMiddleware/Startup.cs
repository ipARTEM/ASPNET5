using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A009RouterMiddleware
{
    public class Startup
    {
        //public void Configure(IApplicationBuilder app)
        //{
        //    var routeBuilder = new RouteBuilder(app);

        //    routeBuilder.MapRoute("{controller}/{action}",
        //        async context => {
        //            context.Response.ContentType = "text/html; charset=utf-8";
        //            await context.Response.WriteAsync("двухсегментный запрос");
        //        });


        //    routeBuilder.MapRoute("{controller}/{action}/{id}",
        //        async context => {
        //            context.Response.ContentType = "text/html; charset=utf-8";
        //            await context.Response.WriteAsync("трехсегментный запрос");
        //        });

        //    app.UseRouter(routeBuilder.Build());

        //    app.Run(async (context) =>
        //    {
        //        await context.Response.WriteAsync("Hello World!");
        //    });
        //}

        //public void ConfigureServices(IApplicationBuilder app)
        //{
        //    // определ€ем обработчик маршрута
        //    var myRouteHandler = new RouteHandler(Handle);
        //    // создаем маршрут, использу€ обработчик
        //    var routeBuilder = new RouteBuilder(app, myRouteHandler);
        //    // само определение маршрута - он должен соответствовать запросу {controller}/{action}
        //    routeBuilder.MapRoute("default", "{controller}/{action}");
        //    // строим маршрут
        //    app.UseRouter(routeBuilder.Build());

        //    app.Run(async (context) =>
        //    {
        //        await context.Response.WriteAsync("Hello World!");
        //    });
        //}


        //private async Task Handle(HttpContext context)
        //{
        //    await context.Response.WriteAsync("Hello ASP.NET Core!");
        //}

        //************************************

        public void Configure(IApplicationBuilder app)
        {
            var routeBuilder = new RouteBuilder(app);



            //routeBuilder.MapRoute("{controller}/{action}",
            //    async context => {
            //        context.Response.ContentType = "text/html; charset=utf-8";
            //        await context.Response.WriteAsync("двухсегментный запрос");
            //    });

            //********************************

            //routeBuilder.MapGet("{controller}/{action}", async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello From MapGet!");
            //});

            //**************************

            routeBuilder.MapMiddlewareGet("{controller}/{action}", app =>
            {
                app.Run(async context =>
                {
                    await context.Response.WriteAsync("Hello from MapMiddlewareGet");
                });
            });


            routeBuilder.MapRoute("{controller}/{action}/{id}",
                async context => {
                    context.Response.ContentType = "text/html; charset=utf-8";
                    await context.Response.WriteAsync("трехсегментный запрос");
                });


            app.UseRouter(routeBuilder.Build());

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}

    
