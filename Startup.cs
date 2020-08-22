using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace cloud_run_events_untyped
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
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

            /* app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    Console.WriteLine("GET endpoint called");
                    var target = Environment.GetEnvironmentVariable("TARGET") ?? "World";
                    await context.Response.WriteAsync($"Hello {target}!\n");
                });

                endpoints.MapPost("/", async context =>
                {
                    Console.WriteLine("POST endpoint called");
                    var source = context.Request.Headers["ce-source"];
                    await context.Response.WriteAsync($"source: {source}\n");
                }); 
            });*/
        }
    }
}
