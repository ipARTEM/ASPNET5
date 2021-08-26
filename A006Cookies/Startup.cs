using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A006Cookies
{
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
            //***************************      Сессии
            services.AddDistributedMemoryCache();
            services.AddSession();

            //***************************      SessionOptions

            //services.AddDistributedMemoryCache();
            //services.AddSession(options =>
            //{
            //    options.Cookie.Name = ".MyApp.Session";
            //    options.IdleTimeout = TimeSpan.FromSeconds(3600);
            //    options.Cookie.IsEssential = true;
            //});

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            //************************

            //app.Use(async (context, next) =>
            //{
            //    context.Items["text"] = "Text from HttpContext.Items";
            //    await next.Invoke();
            //});

            //app.Run(async (context) =>
            //{
            //    context.Response.ContentType = "text/html; charset=utf-8";
            //    await context.Response.WriteAsync($"Текст: {context.Items["text"]}");
            //});

            //*******************

            //app.Use(async (context, next) =>
            //{
            //    context.Items.Add("text", "Привет мир");
            //    await next.Invoke();
            //});

            //app.Run(async (context) =>
            //{
            //    context.Response.ContentType = "text/html; charset=utf-8";
            //    if (context.Items.ContainsKey("text"))
            //        await context.Response.WriteAsync($"Текст: {context.Items["text"]}");
            //    else
            //        await context.Response.WriteAsync("Случайный текст");
            //});

            //**********************

            app.UseSession();      // добавляем механизм работы с сессиями

            app.Run(async (context) =>
            {
                //if (context.Request.Cookies.ContainsKey("name"))
                //{
                //    string name = context.Request.Cookies["name"];
                //    await context.Response.WriteAsync($"Hello {name}!");
                //}
                //else
                //{
                //    context.Response.Cookies.Append("name", "Tom");
                //    await context.Response.WriteAsync("Hello World!");
                //}

                //***************************     Cookies

                //string login;
                //if (context.Request.Cookies.TryGetValue("name", out login))
                //{
                //    await context.Response.WriteAsync($"Hello {login}!");
                //}
                //else
                //{
                //    context.Response.Cookies.Append("name", "Tomson");
                //    await context.Response.WriteAsync("Hello World!");
                //}

                //***************************      Session

                //app.Run(async (context) =>
                //{
                //    if (context.Session.Keys.Contains("name"))
                //        await context.Response.WriteAsync($"Hello {context.Session.GetString("name")}!");
                //    else
                //    {
                //        context.Session.SetString("name", "Tom");
                //        await context.Response.WriteAsync("Hello World!");
                //    }
                //});


                //***************************

                app.UseSession();
                app.Run(async (context) =>
                {
                    if (context.Session.Keys.Contains("person"))
                    {
                        Person person = context.Session.Get<Person>("person");
                        await context.Response.WriteAsync($"Hello {person.Name}, your age: {person.Age}!");
                    }
                    else
                    {
                        Person person = new Person { Name = "Tom", Age = 22 };
                        context.Session.Set<Person>("person", person);
                        await context.Response.WriteAsync("Hello World!");
                    }
                });



            });

        }
    }
}
