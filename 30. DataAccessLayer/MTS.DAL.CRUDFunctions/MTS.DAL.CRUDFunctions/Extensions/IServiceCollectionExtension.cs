using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MTS.PL.DatabaseAccess.CRUD.Account;
using MTS.PL.DatabaseAccess.DataContext;
using MTS.PL.DatabaseAccess.CRUD.Identity;
using MTS.PL.Infra.Interfaces;
using MTS.PL.Interfaces.Standard;
using MTS.PL.Infra.Entities;
using MTS.PL.Infra.Interfaces.Standard.DatabaseAdapter;
using MTS.PL.Entities.Core;

namespace MTS.PL.DatabaseAccess.Extensions
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
                .AddIdentity<DALUserAccount, IdentityRole>()
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
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.Audience = "MTS-Audience";
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
