using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MTS.BL.DatabaseAccess.CRUD.Account;
using MTS.BL.DatabaseAccess.DataContext;
using MTS.BL.Infra.EmailLibrary;
using MTS.BL.Infra.Entities;
using MTS.BL.Infra.Interfaces;
using System;
using System.Text;
using MTS.BL.DatabaseAccess.Identity;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MTS.DAL.DatabaseAccess.Utils;

namespace MTS.BL.DatabaseAccess.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddDatabaseLibrary(this IServiceCollection services)
        {
            DbConfigurations configurations = new DbConfigurations();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configurations.SqlConnectionString));

            services.Configure<IdentityOptions>(options => options = configurations.IdentityOptions);

            services
                .AddIdentity<EFUserAccount, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders()
                .AddRoles<IdentityRole>();

            services
                .AddAuthentication(options => options = new AuthenticationOptionsBuilder())
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => 
                {
                    options.RequireHttpsMetadata = true;
                    options.SaveToken = true;
                    options.Audience = "https://localhost:5001/";
                    options.TokenValidationParameters = configurations.TokenValidationParameters;
                });

            services.Configure<AuthMessageSenderOptions>(configurations.AuthMessageSenderOptions);

            services.AddSingleton<IEmailSender, EmailSender>();

            services.AddTransient<IAccountAdapter, AccountAdapter>();

            services.AddTransient<IIdentityAdapter, IdentityAdapter>();

            services.AddSingleton<DbConfigurations>();

            return services;
        }
    }
}
