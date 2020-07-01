﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MTS.BL.API.Utils.ExceptionHandler;
using MTS.BL.DatabaseAccess.CRUD.Account;
using MTS.BL.DatabaseAccess.Extensions;
using MTS.BL.Infra.Interfaces;

namespace MTS.BL.API
{
    /// <summary>
    /// Transient objects are always different; a new instance is provided to every controller and every service.
    /// Scoped objects are the same within a request, but different across different requests.
    /// Singleton objects are the same for every object and every request.
    /// </summary>

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("APICorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddDatabaseLibrary();

            services.AddAuthorization();

            services.AddControllers();

            services.AddScoped<IExceptionHandler, ExceptionHandler>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("APICorsPolicy");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}