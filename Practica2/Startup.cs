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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var msg = $"Ambiente actual de la app: {env.EnvironmentName}";
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.Run(async (context) =>
                {
                    msg = "El ambiente es de desarrollo";
                    await context.Response.WriteAsync(msg);
                });
            }
            else
            {
                app.Run(async (context) =>
                {
                    msg = $"En almbiente actual no es de desarrollo. Es de {env.EnvironmentName}";
                    await context.Response.WriteAsync(msg);
                });
            }

            
        }
    }
}
