using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Practica2
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            // primer middleware de la aplicación:

            // Hello world middleware
            app.Use(async (ctx, next) =>
            {
                if (ctx.Request.Path == "/hello-world")
                {
                    // Procesa la petición y no permite la ejecución de middlewares posteriores
                    await ctx.Response.WriteAsync("Hello, world!");
                }
                else
                {
                    // Pasa el control al siguiente middleware
                    await next();
                }
            });

            //segundo middleware:
            app.Use(async (ctx, next) =>
            {
                if (ctx.Request.Path.ToString().StartsWith("/hello"))
                {
                    // Procesa la petición y no permite la ejecución de otros middlewares
                    await ctx.Response.WriteAsync("Hello, user!");
                }
                else
                {
                    // Pasa la petición al siguiente middleware
                    await next();
                }
            });

            // Request Info middleware
            app.Run(async ctx =>
            {
                await ctx.Response.WriteAsync($"Path requested: {ctx.Request.Path}");
            });
        }
    }
}
