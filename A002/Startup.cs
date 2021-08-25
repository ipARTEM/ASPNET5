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
        public Startup(IConfiguration config)
        {
            // ��������� ������������
            //var builder = new ConfigurationBuilder()
            //    .AddInMemoryCollection(new Dictionary<string, string>
            //    {
            //        {"firstname", "Tom"},
            //        {"age", "31"}
            //    });

            //*********************************

            //string[] args = { "name=Alice", "age=29" };  // ��������������� ��������� ������
            //var builder = new ConfigurationBuilder().AddCommandLine(args);
            //******************************

            //var builder = new ConfigurationBuilder()
            //    //.AddJsonFile("conf.json")
            //    //.AddJsonFile("myconfig.json")
            //    //.AddXmlFile("config.xml")
            //    .AddIniFile("conf.ini")
            //    ;
            //*********************
            //var builder = new ConfigurationBuilder()
            //                .AddJsonFile("conf.json")
            //                .AddEnvironmentVariables()
            //                .AddInMemoryCollection(new Dictionary<string, string>
            //                {
            //                    {"name", "Tom"},
            //                    {"age", "31"}
            //                })
            //                 .AddConfiguration(config);

            //***************************

            var builder = new ConfigurationBuilder()
               .AddJsonFile("project.json");

            // ������� ������������
            AppConfiguration = builder.Build();

        }
        // ��������, ������� ����� ������� ������������
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

            //var color = AppConfiguration["color"];
            ////var text = AppConfiguration["text"];

            //string text = AppConfiguration["JAVA_HOME"]; // ��������� � ���������� ����� ���������

            //app.Run(async (context) =>
            //{
            //    //await context.Response.WriteAsync($"{AppConfiguration["firstname"]} {AppConfiguration["lastname"]} - {AppConfiguration["age"]}");

            //    await context.Response.WriteAsync($"<p style='color:{color};'>{text}</p>");
            //});

            //*******************************

            //app.UseMiddleware<ConfigMiddleware>();

            //*******************************

            string projectJsonContent = GetSectionContent(AppConfiguration);
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("{\n" + projectJsonContent + "}");
            });
        }

            private string GetSectionContent(IConfiguration configSection)
            {
                string sectionContent = "";
                foreach (var section in configSection.GetChildren())
                {
                    sectionContent += "\"" + section.Key + "\":";
                    if (section.Value == null)
                    {
                        string subSectionContent = GetSectionContent(section);
                        sectionContent += "{\n" + subSectionContent + "},\n";
                    }
                    else
                    {
                        sectionContent += "\"" + section.Value + "\",\n";
                    }
                }
                return sectionContent;
            }

        }
}