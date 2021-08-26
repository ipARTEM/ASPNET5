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

namespace A004
{
    public class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("person.json")
                //.AddXmlFile("person.xml")
                ;
            AppConfiguration = builder.Build();
        }
        public IConfiguration AppConfiguration { get; set; }

        public void Configure(IApplicationBuilder app)
        {
            //var tom = new Person();
            //AppConfiguration.Bind(tom);
            //****************************

            Company company = AppConfiguration.GetSection("company").Get<Company>();


            app.Run(async (context) =>
            {
                //string name = $"<p>Name: {tom.Name}</p>";
                //string age = $"<p>Age: {tom.Age}</p>";
                //string company = $"<p>Company: {tom.Company?.Title}</p>";
                ////string langs = "<p>Languages:</p><ul>";
                //foreach (var lang in tom.Languages)
                //{
                //    langs += $"<li><p>{lang}</p></li>";
                //}
                //langs += "</ul>";

                // await context.Response.WriteAsync($"{name}{age}{company}{langs}");

                //*************************

                app.Run(async (context) =>
                {
                    await context.Response.WriteAsync($"<p>Title: {company.Title}</p><p>Country: {company.Country}</p>");
                });


            });
        }
    }
}