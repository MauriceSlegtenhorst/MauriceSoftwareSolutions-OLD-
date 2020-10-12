using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MTS.Core.GlobalLibrary;
using MTS.PL.Infra.Interfaces.Standard;
using MTS.PL.Web.Blazor.Client.Authentification;
using MTS.PL.Web.Blazor.Client.Utils;
using MTS.PL.Web.Blazor.Client.Utils.Services.Dialog;
using MTS.PL.Web.Blazor.Client.Utils.Services.EditPage;
using MTS.PL.Web.Blazor.Client.Utils.Services.Spinner;
using MTS.PL.Web.Blazor.Client.Utils.Services.Toast;
using Syncfusion.Blazor;
using Syncfusion.Licensing;

namespace MTS.PL.Web.Blazor.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            SyncfusionLicenseProvider.RegisterLicense("MzMwMTg3QDMxMzgyZTMzMmUzMElRdk1vMmZUSmc5dTVrUXVtR1ZLdEhiZVhTLy9VSno4dUFJTGgzQWk3R1E9");

            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("app");

            builder.Services.AddSyncfusionBlazor();

            #region Global UI
            builder.Services.AddSingleton<IToastService, ToastService>();
            builder.Services.AddSingleton<ISpinnerService, SpinnerService>();
            builder.Services.AddScoped<IDialogService, DialogService>();
            builder.Services.AddSingleton<IEditPageService, EditPageService>();
            #endregion

            #region HttpClientFactory
            builder.Services.AddTransient<AuthenticationHandler>();

            builder.Services.AddHttpClient(
                BlazorConstants.HttpClients.API,
                client =>
                {
                    client.BaseAddress = new Uri(Constants.API_BASE_ADDRESS);
                })
                .AddHttpMessageHandler<AuthenticationHandler>();
            #endregion

            #region Security
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();

            builder.Services.AddScoped<JWTAuthStateProvider>();

            builder.Services.AddScoped<AuthenticationStateProvider, JWTAuthStateProvider>(
                provider => provider.GetRequiredService<JWTAuthStateProvider>());

            builder.Services.AddScoped<ILoginService, JWTAuthStateProvider>(
                provider => provider.GetRequiredService<JWTAuthStateProvider>());
            #endregion

            await builder.Build().RunAsync();
        }
    }
}
