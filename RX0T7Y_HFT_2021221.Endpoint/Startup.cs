using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RX0T7Y_HFT_2021221.Data;
using RX0T7Y_HFT_2021221.Logic;
using RX0T7Y_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RX0T7Y_HFT_2021221.Endpoint
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();


            services.AddTransient<IBookLogic, BookLogic>();
            services.AddTransient<IAuthorLogic, AuthorLogic>();
            services.AddTransient<IPublisherLogic, PublisherLogic>();

            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IPublisherRepository, PublisherRepository>();

            services.AddTransient<BookAuthorPublisherDbContext, BookAuthorPublisherDbContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
