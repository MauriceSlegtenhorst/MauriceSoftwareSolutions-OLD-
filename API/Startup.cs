using API.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SharedLibrary.Data;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("localdatabaseconnection")));

            //services.AddIdentity<UserAccount, IdentityRole>(option =>
            //{
            //    IConfigurationSection sighnInOptions = Configuration.GetSection(nameof(IdentityOptions))
            //    .GetSection(nameof(SignInOptions));
           
            //    IConfigurationSection userOptions = Configuration.GetSection(nameof(IdentityOptions))
            //    .GetSection(nameof(UserOptions));
            
            //    option.SignIn.RequireConfirmedAccount = sighnInOptions.GetValue<bool>(nameof(SignInOptions.RequireConfirmedAccount));
                
            //    option.SignIn.RequireConfirmedEmail = sighnInOptions.GetValue<bool>(nameof(SignInOptions.RequireConfirmedAccount));

            //    option.User.RequireUniqueEmail = userOptions.GetValue<bool>(nameof(UserOptions.RequireUniqueEmail));
            //})
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            // Set the default authentication policy to require users to be authenticated
            services.AddControllers(
            //    config => 
            //{
            //    var policy = new AuthorizationPolicyBuilder()
            //             .RequireAuthenticatedUser()
            //             .Build();
            //    config.Filters.Add(new AuthorizeFilter(policy));
            //}
            );

            var builder = services.AddIdentityServer()
                .AddInMemoryApiResources(Config.Apis)
                .AddInMemoryClients(Config.Clients)
                .AddDeveloperSigningCredential();

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = Constants.BASE_ADDRESS;
                    options.RequireHttpsMetadata = false;

                    options.Audience = "api1";
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
