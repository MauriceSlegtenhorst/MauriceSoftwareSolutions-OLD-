using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SharedLibrary.Models.Email;
using SharedLibrary.Services;
using SharedDependencyInterfaces.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.CodeAnalysis.Options;

namespace WebServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication(Constants.CookieConfigurations.DEFAULT_SCHEME)
                .AddCookie(Constants.CookieConfigurations.DEFAULT_SCHEME,
           (options) =>
           {
               options.AccessDeniedPath = "/Areas/Identity/Pages/Account/AccessDenied";
               options.LoginPath = "/Areas/Identity/Pages/Account/Login";
               //options.SlidingExpiration = true;
           });
                //.AddOpenIdConnect("oidc", options =>
                //{
                //      options.SignInScheme = "msc_cookies";
                //      options.Authority = "https://localhost:44370";
                //      options.ClientId = "mvc";
                //      options.ResponseType = "code id_token";
                //      //options.CallbackPath = new PathString("...");
                //      //options.SignedOutCallbackPath = new PathString("...");

                //      options.Scope.Add("openid");
                //      options.Scope.Add("profile");

                //      options.Scope.Add("address");
                //      options.Scope.Add("email");
                //      options.Scope.Add("roles");
                //      options.Scope.Add("subscriptionlevel");
                //      options.Scope.Add("country");
                //      options.Scope.Add("imagegalleryapi");
                //      options.Scope.Add("offline_access");

                //      options.SaveTokens = true;
                //      options.ClientSecret = "secret";

                //      options.GetClaimsFromUserInfoEndpoint = true;
                //      options.ClaimActions.Remove("amr"); //this ensures that the amr claim is not filtered out.
                //      options.ClaimActions.DeleteClaim("sid");
                //      options.ClaimActions.DeleteClaim("idp");
                //      ////options.ClaimActions.DeleteClaim("address");
                //      options.ClaimActions.MapUniqueJsonKey("role", "role"); //Added mappings to the role claim.
                //      //options.ClaimActions.MapUniqueJsonKey("subscriptionlevel", "subscriptionlevel");
                //      //options.ClaimActions.MapUniqueJsonKey("country", "country");

                //      //options.TokenValidationParameters = new TokenValidationParameters
                //      //{
                //      //    NameClaimType = JwtClaimTypes.GivenName,
                //      //    RoleClaimType = JwtClaimTypes.Role,
                //      //};

                //});

            services.Configure<AuthMessageSenderOptions>(Configuration.GetSection("AuthMessageSenderOptions"));
            services.AddSingleton<IEmailSender, EmailSender>();

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
