using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StudyNetCore.Service;

namespace StudyNetCore
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IStudentService,StudentService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.Use(async (context,next) =>
            {
                logger.LogInformation("管道1开启");
                await context.Response.WriteAsync("Hello World!");
                await next();
                logger.LogInformation("管道1结束");
            });
            app.Run(async (context) =>
            {
                logger.LogInformation("管道2开启");
                await context.Response.WriteAsync("许嵩!");
                logger.LogInformation("管道2结束");

            });
        }
    }
}
