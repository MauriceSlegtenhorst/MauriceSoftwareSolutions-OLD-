using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MTS.DAL.DatabaseAccess.CRUD.Account;
using MTS.DAL.DatabaseAccess.DataContext;
using MTS.DAL.Infra.EmailLibrary;
using MTS.DAL.Infra.Entities;
using MTS.DAL.Infra.Interfaces;
using MTS.DAL.DatabaseAccess.CRUD.Identity;

namespace MTS.DAL.DatabaseAccess.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddDatabaseLibrary(this IServiceCollection services)
        {
            DbConfigurations configurations = new DbConfigurations();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configurations.SqlConnectionString, 
                options => options.MigrationsAssembly("MTS.BL.API")));

            services.Configure<IdentityOptions>(options => options = configurations.IdentityOptions);

            services
                .AddIdentity<EFUserAccount, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders()
                .AddRoles<IdentityRole>();

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.RequireHttpsMetadata = true;
                    options.SaveToken = true;
                    options.Audience = "https://localhost:5001/";
                    options.TokenValidationParameters = configurations.TokenValidationParameters;
                });

            services.Configure<AuthMessageSenderOptions>(configurations.AuthMessageSenderOptions);

            services.AddSingleton<IEmailSender, EmailSender>();

            services.AddSingleton<ISeedData, SeedData>();

            services.AddTransient<IAccountAdapter, AccountAdapter>();

            services.AddTransient<IIdentityAdapter, IdentityAdapter>();

            services.AddSingleton<DbConfigurations>();

            return services;
        }
    }
}
