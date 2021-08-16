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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            ////middleware 
            //if (env.IsDevelopment())
            //{
            //    //��������� ��������� ������ - Diagnostics.
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}


            ////�������������� ��� ������� HTTP �� HTTPS
            //app.UseHttpsRedirection();

            //// ������������� ��������� ��������� ����������� ������
            //app.UseStaticFiles();

            ////��������� ������������� - EndpointRoutingMiddleware.
            //app.UseRouting();

            ////������������� ��������� ��������������
            //app.UseAuthorization();

            ////��������� EndpointMiddleware, ������� ���������� �����, ���� ������ ������ �� �������� "/"
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
            //    await next.Invoke();    // ����� app.Run
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
            // �����  ��������� ������
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

            //    if (env.IsEnvironment("Test")) // ���� ������ � ��������� "Test"
            //    {
            //        await context.Response.WriteAsync("� ��������� ������������");
            //    }
            //    else
            //    {
            //        await context.Response.WriteAsync("� �������� ���������� ��� � ����������");
            //    }
            //});

            //***************************

            //app.UseStaticFiles();   // ��������� ��������� ����������� ������

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
            //options.DefaultFileNames.Clear(); // ������� ����� ������ �� ���������
            //options.DefaultFileNames.Add("hello.html"); // ��������� ����� ��� �����
            //app.UseDefaultFiles(options); // ��������� ����������

            //app.UseStaticFiles();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World12");
            //});

            //****************************

            app.UseDirectoryBrowser();   //  ��������� ������������� ������������� ���������� ��������� �� �����:
            app.UseStaticFiles();
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World");
            });

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
