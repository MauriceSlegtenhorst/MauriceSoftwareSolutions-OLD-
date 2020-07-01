using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MTS.BL.DatabaseAccess.CRUD.Account;
using MTS.BL.DatabaseAccess.DataContext;
using MTS.BL.Infra.EmailLibrary;
using MTS.BL.Infra.Entities;
using MTS.BL.Infra.Interfaces;
using MTS.BL.DatabaseAccess.DataContext;
using Newtonsoft.Json;
using System;
using System.Text;
using MTS.BL.DatabaseAccess.Identity;

namespace MTS.BL.DatabaseAccess.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddDatabaseLibrary(this IServiceCollection services)
        {
            DbConfigurations configurations = new DbConfigurations();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configurations.SqlConnectionString));

            services.AddIdentity<EFUserAccount, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurations.IssuerSigningKey)),
                    ClockSkew = TimeSpan.Zero
                });

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;

                // Sign in settings
                options.SignIn.RequireConfirmedEmail = true;
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
