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

namespace A005
{
    public class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("person.json");
            AppConfiguration = builder.Build();
        }

        public IConfiguration AppConfiguration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            // создание объекта Person по ключам из конфигурации
            //services.Configure<Person>(AppConfiguration);

            //********************

            services.Configure<Person>(AppConfiguration);
            services.Configure<Company>(AppConfiguration.GetSection("company"));
            services.Configure<Person>(opt =>
            {
                opt.Age = 22;
            });


        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<PersonMiddleware>();
        }
    }

}
