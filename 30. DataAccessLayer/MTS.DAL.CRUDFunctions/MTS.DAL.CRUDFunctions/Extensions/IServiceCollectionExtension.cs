using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MTS.DAL.DatabaseAccess.CRUD.Account;
using MTS.DAL.DatabaseAccess.DataContext;
using MTS.DAL.DatabaseAccess.CRUD.Identity;
using MTS.DAL.Interfaces.Standard;
using MTS.DAL.Entities.Core;
using MTS.BL.Infra.Entities;
using MTS.BL.Infra.Interfaces;
using MTS.BL.Infra.Interfaces.Standard.DatabaseAdapter;
using MTS.DAL.DatabaseAccess.CRUD.EditPages;
using MTS.DAL.DatabaseAccess.CRUD.Credit;

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

            services.AddTransient<IEditPageAdapter, EditPagesAdapter>();

            services.AddTransient<ICreditAdapter, CreditAdapter>();

            services.AddSingleton<DbConfigurations>();

            return services;
        }
    }
}
