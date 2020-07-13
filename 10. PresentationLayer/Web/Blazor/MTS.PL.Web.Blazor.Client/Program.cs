using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MTS.Core.GlobalLibrary;
using MTS.PL.Infra.Interfaces.Standard;
using MTS.PL.Web.Blazor.Client.Authentification;
using MTS.PL.Web.Blazor.Client.Entities;
using MTS.PL.Web.Blazor.Client.Utils;
using Syncfusion.Blazor;
using Syncfusion.Licensing;

namespace MTS.PL.Web.Blazor.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            SyncfusionLicenseProvider.RegisterLicense("##SyncfusionLicense##");

            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("app");

            builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(Constants.API_BASE_ADDRESS) });

            builder.Services.AddSingleton<IStateManager, StateManager>();

            #region Security
            builder.Services.AddOptions();
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
