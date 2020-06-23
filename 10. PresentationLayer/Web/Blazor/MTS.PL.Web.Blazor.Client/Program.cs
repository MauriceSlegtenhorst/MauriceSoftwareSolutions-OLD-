using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MTS.Core.GlobalLibrary;
using MTS.PL.Infra.InjectionLibrary;
using MTS.PL.Web.Blazor.Client.Authentification;
using MTS.PL.Web.Blazor.Client.Pages.Account.CRUD;
using Syncfusion.Blazor;

namespace MTS.PL.Web.Blazor.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // TODO Store somewhere better and secure
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjc0NTg2QDMxMzgyZTMxMmUzMFlqcVFDaEFIRGlpVW13aU1jeWhzUlFod0YwM09QKzhyQ3ljOW92V3padDA9");
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(Constants.API_BASE_ADDRESS) });
            builder.Services.AddScoped<APIAccountsAdapter>();


            #region Security
            builder.Services.AddAuthorizationCore();

            builder.Services.AddScoped<JWTAuthStateProvider>();

            builder.Services.AddScoped<AuthenticationStateProvider, JWTAuthStateProvider>(
                provider => provider.GetRequiredService<JWTAuthStateProvider>());

            builder.Services.AddScoped<ILoginService, JWTAuthStateProvider>(
                provider => provider.GetRequiredService<JWTAuthStateProvider>());
            #endregion

            builder.Services.AddSyncfusionBlazor();
            await builder.Build().RunAsync();
        }
    }
}
