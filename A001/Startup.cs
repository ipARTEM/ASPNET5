using A001.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A001
{
    public class Startup
    {

        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddTransient<IMessageSender, EmailMessageSender>();
        //    //services.AddTransient<IMessageSender, SmsMessageSender>();

        //    //services.AddTransient<TimeService>();

        //    //services.AddTimeService(); //через расширение
        //}


        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMessageSender messageSender)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }

        //    app.UseRouting();

        //    app.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapGet("/", async context =>
        //        {
        //            await context.Response.WriteAsync(messageSender.Send());
        //        });
        //    });
        //}

        //public void Configure(IApplicationBuilder app, TimeService timeService)
        //{
        //    app.Run(async (context) =>
        //    {
        //        context.Response.ContentType = "text/html; charset=utf-8";
        //        await context.Response.WriteAsync($"Текущее время: {timeService?.GetTime()}");
        //    });
        //}

        // Получаем зависимость IMessageSender
        //public void Configure(IApplicationBuilder app, IMessageSender sender)
        //{
        //    app.Run(async (context) =>
        //    {
        //        await context.Response.WriteAsync(sender.Send());
        //    });
        //}

        //*******************************

        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddTransient<IMessageSender, EmailMessageSender>();
        //    services.AddTransient<MessageService>();
        //}

        //public void Configure(IApplicationBuilder app, MessageService messageService)
        //{
        //    app.Run(async (context) =>
        //    {
        //        await context.Response.WriteAsync(messageService.Send());
        //    });
        //}

        //*************************************    service locator

        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddTransient<IMessageSender, EmailMessageSender>();
        //}
        //public void Configure(IApplicationBuilder app)
        //{
        //    app.Run(async (context) =>
        //    {
        //        IMessageSender messageSender = context.RequestServices.GetService<IMessageSender>();
        //        context.Response.ContentType = "text/html;charset=utf-8";
        //        await context.Response.WriteAsync(messageSender.Send());
        //    });
        //}

        //**************************        ApplicationServices 

        //public void Configure(IApplicationBuilder app)
        //{
        //    app.Run(async (context) =>
        //    {
        //        IMessageSender messageSender = app.ApplicationServices.GetService<IMessageSender>();
        //        context.Response.ContentType = "text/html;charset=utf-8";
        //        await context.Response.WriteAsync(messageSender.Send());
        //    });
        //}

        //******************************       Invoke/InvokeAsync компонентов middleware

        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddTransient<IMessageSender, EmailMessageSender>();
        //}
        //public void Configure(IApplicationBuilder app)
        //{
        //    app.UseMiddleware<MessageMiddleware>();
        //}

        //***********************************
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddTransient<ICounter, RandomCounter>();
        //    services.AddTransient<CounterService>();
        //}
        //********************************
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddSingleton<ICounter, RandomCounter>();
        //    services.AddSingleton<CounterService>();
        //}
        //public void Configure(IApplicationBuilder app)
        //{
        //    app.UseMiddleware<CounterMiddleware>();
        //}

        //********************************

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<TimeService>();

            services.AddTransient<ITimer, Timer>();
            services.AddScoped<TimeService>();
        }
        public void Configure(IApplicationBuilder app)
        {
            //app.UseMiddleware<TimerMiddleware>();
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            //************************

            app.UseDeveloperExceptionPage();
            app.UseMiddleware<TimerMiddleware>();
        }


    }
}
