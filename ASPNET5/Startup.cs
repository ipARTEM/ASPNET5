using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private IServiceCollection _services;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddRazorPages();
            //************************
            //services.AddHttpsRedirection(options =>
            //{
            //    options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
            //    options.HttpsPort = 44388;
            //});

            //*********************

            _services = services;                //просмотр всех видов сервисов

            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(60);
                options.ExcludedHosts.Add("khimin.ru");
                options.ExcludedHosts.Add("www.khimin.ru");
            });

            //****************************

            


        }
        


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            ////middleware 
            //if (env.IsDevelopment())
            //{
            //    //Компонент обработки ошибок - Diagnostics.
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}


            ////перенаправляет все запросы HTTP на HTTPS
            //app.UseHttpsRedirection();

            //// предоставляет поддержку обработки статических файлов
            //app.UseStaticFiles();

            ////Компонент маршрутизации - EndpointRoutingMiddleware.
            //app.UseRouting();

            ////предоставляет поддержку аутентификации
            //app.UseAuthorization();

            ////Компонент EndpointMiddleware, который отправляет ответ, если запрос пришел по маршруту "/"
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapRazorPages();
            //});

            //*****************

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            //*******************
            //int x = 5;
            //int y = 8;
            //int z = 0;
            //app.Use(async (context, next) =>
            //{
            //    z = x * y;
            //    await next.Invoke();
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync($"x * y = {z}");
            //});

            //*************************

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("<p>Hello world!</p>");
            //    await next.Invoke();
            //});

            //app.Run(async (context) =>
            //{
            //    await Task.Delay(1000); 
            //    await context.Response.WriteAsync("<p>Good bye, World...</p>");
            //});

            //**************************

            //int x = 2;
            //app.Use(async (context, next) =>
            //{
            //    x = x * 2;      // 2 * 2 = 4
            //    await next.Invoke();    // вызов app.Run
            //    x = x * 2;      // 8 * 2 = 16
            //    await context.Response.WriteAsync($"Result: {x}");
            //});

            //app.Run(async (context) =>
            //{
            //    x = x * 2;  //  4 * 2 = 8
            //    await Task.FromResult(0);
            //});

            //**********************

            //app.Map("/index", Index);
            //app.Map("/about", About);

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Page Not Found");
            //});

            //***********************

            //app.Map("/home", home =>
            //{
            //    home.Map("/index", Index);
            //    home.Map("/about", About);
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Page Not Found");
            //});

            //********************
            //app.MapWhen(context => {

            //    return context.Request.Query.ContainsKey("id") &&
            //            context.Request.Query["id"] == "5";
            //}, HandleId);

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Good bye, World...");
            //});

            //**************************
            //app.UseMiddleware<TokenMiddleware>();
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World");
            //});

            //*****************************

            //app.UseToken();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World10");
            //});

            //*******************************
            // извне  получение токина
            //app.UseToken("8888");

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World");
            //});

            //****************************

            //app.UseMiddleware<AuthenticationMiddleware>();
            //app.UseMiddleware<RoutingMiddleware>();

            //*******************************

            //app.UseMiddleware<ErrorHandlingMiddleware>();
            //app.UseMiddleware<AuthenticationMiddleware>();        //https://localhost:44397/about?token=121321
            //app.UseMiddleware<RoutingMiddleware>();

            //**************************

            //app.Run(async (context) =>
            //{
            //    context.Response.Headers["Content-Type"] = "text/html; charset=utf-8";

            //    if (env.IsEnvironment("Test")) // Если проект в состоянии "Test"
            //    {
            //        await context.Response.WriteAsync("В состоянии тестирования");
            //    }
            //    else
            //    {
            //        await context.Response.WriteAsync("В процессе разработки или в продакшене");
            //    }
            //});

            //***************************

            //app.UseStaticFiles();   // добавляем поддержку статических файлов

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World");        // /index.html
            //});

            //************************************

            //app.UseDefaultFiles();
            //app.UseStaticFiles();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World11");
            //});

            //*************************************

            //DefaultFilesOptions options = new DefaultFilesOptions();
            //options.DefaultFileNames.Clear(); // удаляем имена файлов по умолчанию
            //options.DefaultFileNames.Add("hello.html"); // добавляем новое имя файла
            //app.UseDefaultFiles(options); // установка параметров

            //app.UseStaticFiles();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World12");
            //});

            //****************************

            //app.UseDirectoryBrowser();   //  позволяет пользователям просматривать содержимое каталогов на сайте:
            //app.UseStaticFiles();
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World");
            //});

            //***********************************

            //app.UseDirectoryBrowser(new DirectoryBrowserOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\html")),

            //    RequestPath = new PathString("/pages")
            //});
            //app.UseStaticFiles();
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World");
            //});

            //***********************************

            //app.UseStaticFiles(); // обрабатывает все запросы к wwwroot
            //app.UseStaticFiles(new StaticFileOptions() // обрабатывает запросы к каталогу wwwroot/html
            //{
            //    FileProvider = new PhysicalFileProvider(
            //        Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\html")),
            //    RequestPath = new PathString("/pages")
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World");
            //});

            //*****************************

            //app.UseFileServer();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World");
            //});

            //*********************************

            //app.UseFileServer(new FileServerOptions
            //{
            //    EnableDirectoryBrowsing = true,
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\html")),
            //    RequestPath = new PathString("/pages"),
            //    EnableDefaultFiles = false
            //});

            //***************************
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //app.Run(async (context) =>
            //{
            //    int x = 0;
            //    int y = 8 / x;
            //    await context.Response.WriteAsync($"Result = {y}");

            //});

            //************************************
            //env.EnvironmentName = "Production";
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //app.Run(async (context) =>
            //{
            //    int x = 0;
            //    int y = 8 / x;
            //    await context.Response.WriteAsync($"Result = {y}");
            //});

            //*************************************

            //env.EnvironmentName = "Production";

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/error");
            //}

            //app.Map("/error", ap => ap.Run(async context =>
            //{
            //    await context.Response.WriteAsync("DivideByZeroException occured!");
            //}));

            //app.Run(async (context) =>
            //{
            //    int x = 0;
            //    int y = 8 / x;
            //    await context.Response.WriteAsync($"Result = {y}");
            //});

            //************************************

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //// обработка ошибок HTTP
            ////app.UseStatusCodePages();       // вариант 1

            ////app.UseStatusCodePages("text/plain", "Error. Status code : {0}");       // вариант 2

            //app.UseStatusCodePagesWithReExecute("/error", "?code={0}");        // вариант 3

            //app.Map("/hello", ap => ap.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync($"Hello ASP.NET Core");
            //}));

            //// обработка ошибок HTTP
            //app.UseStatusCodePagesWithReExecute("/error", "?code={0}");

            //app.Map("/error", ap => ap.Run(async context =>
            //{
            //    await context.Response.WriteAsync($"Err: {context.Request.Query["code"]}");
            //}));

            //app.Map("/hello", ap => ap.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync($"Hello ASP.NET Core");
            //}));

            //***********************

            //app.Map("/hello", ap => ap.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync($"Hello ASP.NET Core");
            //}));

            //******************

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseHsts();
            //}


            //app.UseHttpsRedirection();
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            //**************************
            app.Run(async context =>
            {
                var sb = new StringBuilder();
                sb.Append("<h1>Все сервисы</h1>");
                sb.Append("<table>");
                sb.Append("<tr><th>Тип</th><th>Lifetime</th><th>Реализация</th></tr>");
                foreach (var svc in _services)
                {
                    sb.Append("<tr>");
                    sb.Append($"<td>{svc.ServiceType.FullName}</td>");
                    sb.Append($"<td>{svc.Lifetime}</td>");
                    sb.Append($"<td>{svc.ImplementationType?.FullName}</td>");
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
                context.Response.ContentType = "text/html;charset=utf-8";
                await context.Response.WriteAsync(sb.ToString());
            });






        }

        private static void HandleId(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("id is equal to 5");
            });
        }

        private static void Index(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Index");
            });
        }
        private static void About(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("About");
            });
        }
    }
}
