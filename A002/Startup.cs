using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A002
{
    public class Startup
    {
        public Startup()
        {
            // строитель конфигурации
            //var builder = new ConfigurationBuilder()
            //    .AddInMemoryCollection(new Dictionary<string, string>
            //    {
            //        {"firstname", "Tom"},
            //        {"age", "31"}
            //    });

            //*********************************

            //string[] args = { "name=Alice", "age=29" };  // псевдопараметры командной строки
            //var builder = new ConfigurationBuilder().AddCommandLine(args);
            //******************************

            var builder = new ConfigurationBuilder()
                //.AddJsonFile("conf.json")
                //.AddJsonFile("myconfig.json")
                //.AddXmlFile("config.xml")
                .AddIniFile("conf.ini")
                ;


            // создаем конфигурацию
            AppConfiguration = builder.Build();

        }
        // свойство, которое будет хранить конфигурацию
        public IConfiguration AppConfiguration { get; set; }

        public void Configure(IApplicationBuilder app)
        {
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync(AppConfiguration["firstname"]);
            //});

            //***************************

            //AppConfiguration["firstname"] = "alice";
            //AppConfiguration["lastname"] = "simpson";
            //*********************************

            var color = AppConfiguration["color"];
            var text = AppConfiguration["text"];

            app.Run(async (context) =>
            {
                //await context.Response.WriteAsync($"{AppConfiguration["firstname"]} {AppConfiguration["lastname"]} - {AppConfiguration["age"]}");

                await context.Response.WriteAsync($"<p style='color:{color};'>{text}</p>");
            });
        }
    }
}