using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace A007Log
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env
            //,ILogger<Startup> logger
            , ILoggerFactory loggerFactory
            )
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
            //**********************

            //var loggerFactory = LoggerFactory.Create(builder =>        //Фабрика логгера
            //{
            //    builder.AddDebug();
            //    builder.AddConsole();
            //    // настройка фильтров
            //    builder.AddFilter("System", LogLevel.Debug)
            //            .AddFilter<DebugLoggerProvider>("Microsoft", LogLevel.Trace);
            //    builder.AddFilter("System", LogLevel.Debug)
            //.SetMinimumLevel(LogLevel.Debug);   // Определение MinimumLevel


            //});
            //ILogger logger = loggerFactory.CreateLogger<Startup>();


            ////**********************
            //app.Run(async (context) =>
            //{
            //    // пишем на консоль информацию
            //    //logger.LogInformation("Processing request {0}", context.Request.Path);
            //    //или так
            //    //logger.LogInformation($"Processing request {context.Request.Path}");

            //    //*****************************

            //    logger.LogCritical("LogCritical {0}", context.Request.Path);
            //    logger.LogDebug("LogDebug {0}", context.Request.Path);
            //    logger.LogError("LogError {0}", context.Request.Path);
            //    logger.LogInformation("LogInformation {0}", context.Request.Path);
            //    logger.LogWarning("LogWarning {0}", context.Request.Path);

            //    await context.Response.WriteAsync(" Hello!");
            //});

            //***********************

            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
            var logger = loggerFactory.CreateLogger("FileLogger");

            app.Run(async (context) =>
            {
                logger.LogInformation("Processing request {0}", context.Request.Path);
                await context.Response.WriteAsync("Hello World!");
            });


        }
    }
}
