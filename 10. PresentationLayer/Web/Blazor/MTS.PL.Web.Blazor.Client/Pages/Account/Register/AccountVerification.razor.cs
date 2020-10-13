using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using MTS.Core.GlobalLibrary;
using MTS.PL.Web.Blazor.Client.Utils;
using MTS.PL.Web.Blazor.Client.Utils.Services.Spinner;
using MTS.PL.Web.Blazor.Client.Utils.Services.Toast;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MTS.PL.Web.Blazor.Client.Pages.Account.Register
{
    public partial class AccountVerification
    {
        [Inject]
        private ISpinnerService SpinnerService { get; set; }

        [Inject]
        private IHttpClientFactory HttpClientFactory { get; set; }

        [Inject]
        private IToastService ToastService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        private Uri uri;

        private string subTitleContent;

        private string userId;

        private string code;

        protected override async Task OnInitializedAsync()
        {
            subTitleContent = "Status: Unvalidated";

            uri = NavigationManager.ToAbsoluteUri(NavigationManager.Uri);

            await TryParseDataFromQuery();
            
            if(String.IsNullOrEmpty(userId) || String.IsNullOrEmpty(code))
            {
                subTitleContent = "Status: Requesting user email validation";
                // Tell user to check email
            }
            else
            {
                subTitleContent = "Status: Calling server to confirm your account";



                await CallServerToConfirmEmail();
            }

           

            await base.OnInitializedAsync();
        }

        private async Task<bool> CallServerToConfirmEmail()
        {
            var confirmEmailHolder = new
            {
                UserId = userId,
                Code = code
            };

            uri = new Uri($"{Constants.API_BASE_ADDRESS}/{Constants.APIControllers.ACCOUNT}/{Constants.AccountControllerEndpoints.CONFIRM_EMAIL}");

            var client = HttpClientFactory.CreateClient(BlazorConstants.HttpClients.API);

            HttpResponseMessage response = null;

            try
            {
                response = await client.PutAsJsonAsync(uri, confirmEmailHolder);
            }
            catch (Exception)
            {
                ToastService.ShowExceptionToast(new Exception(await response.Content.ReadAsStringAsync()));
            }

            string message = null;

            if (response.IsSuccessStatusCode)
            {
                // TODO move to login page or login user or something like that

                return true;
            }
            else
            {
                message = await response.Content.ReadAsStringAsync();
                ToastService.ShowExceptionToast(new Exception(message));

                // Show message on the screen or popup or both or something like that

                return false;
            }
        }

        private Task<bool> TryParseDataFromQuery()
        {
            // Workaround for long querystrings
            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("userid", out var param) &&
                QueryHelpers.ParseQuery(uri.Query).TryGetValue("code", out var param2))
            {
                userId = param;
                code = param2;
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        private void ProgressCompleted()
        {
            ToastService.ShowSuccessToast("Your email address has successfully been confirmed. It might take some time before Maurice confirms your account.", "Email confirmation complete");
            subTitleContent = "Status: Validated. Awaiting approval";
        }
    }
}
