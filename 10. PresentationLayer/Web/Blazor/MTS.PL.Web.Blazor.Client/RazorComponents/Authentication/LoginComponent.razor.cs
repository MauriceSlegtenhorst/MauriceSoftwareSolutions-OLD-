using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MTS.Core.GlobalLibrary;
using MTS.PL.Infra.Interfaces.Standard;
using MTS.PL.Web.Blazor.Client.Utils;
using MTS.PL.Web.Blazor.Client.Utils.Services.Dialog;
using MTS.PL.Web.Blazor.Client.Utils.Services.Spinner;
using MTS.PL.Web.Blazor.Client.Utils.Services.Toast;
using MTS.PL.Web.Blazor.Client.Utils.Services.Verification;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MTS.PL.Web.Blazor.Client.RazorComponents.Authentication
{
    public partial class LoginComponent : IDisposable
    {
        private const string INVISIBLE = "invisible";

        [Inject]
        private IDialogService DialogService { get; set; }

        [Inject]
        private ILoginService LoginService { get; set; }

        [Inject]
        private ISpinnerService SpinnerService { get; set; }

        [Inject]
        private IToastService ToastService { get; set; }

        [Inject]
        private IHttpClientFactory HttpClientFactory { get; set; }

        private InputModel inputModel;
        private EditContext editContext;
        private string emailValidationCss = INVISIBLE;
        private string passwordValidationCss = INVISIBLE;
        private bool showPassword;
        private bool canSubmit;

        protected override void OnInitialized()
        {
            inputModel = new InputModel();

#if DEBUG
            //TODO Remove this on release
            inputModel.Email = "mauricesoftwaresolution@outlook.com";
            inputModel.Password = "MTS1991Password!";
#endif

            editContext = new EditContext(inputModel);

            editContext.OnValidationStateChanged += OnValidationStateChanged;

            editContext.OnFieldChanged += OnFieldChanged;

            base.OnInitialized();
        }

        private void OnFieldChanged(object sender, FieldChangedEventArgs e)
        {
            
        }

        public void Dispose()
        {
            editContext.OnValidationStateChanged -= OnValidationStateChanged;
            editContext.OnFieldChanged -= OnFieldChanged;
        }

        private void OnValidationStateChanged(object sender, ValidationStateChangedEventArgs eventArgs)
        {
            if (editContext.GetValidationMessages().Any() == false)
            {
                canSubmit = true;
                emailValidationCss = INVISIBLE;
                passwordValidationCss = INVISIBLE;
            }
            else
            {
                canSubmit = false;

                FieldIdentifier emailField = editContext.Field(nameof(inputModel.Email));
                if (editContext.GetValidationMessages(emailField).Any())
                    emailValidationCss = null;

                FieldIdentifier passwordField = editContext.Field(nameof(inputModel.Password));
                if (editContext.GetValidationMessages(passwordField).Any())
                    passwordValidationCss = null;
            }
        }

        private async Task SubmitAsync()
        {
            await SpinnerService.ShowSpinnerAsync("Requesting authorization");

            string requestUrl = $"{Constants.APIControllers.IDENTITY}/{Constants.IdentityControllerEndpoints.LOG_IN}";

            HttpResponseMessage response;

            await SpinnerService.ShowSpinnerAsync();

            try
            {
                response = await HttpClientFactory.CreateClient(BlazorConstants.HttpClients.API).PutAsJsonAsync(requestUrl, inputModel);
            }
            catch (Exception ex)
            {
                ToastService.ShowExceptionToast(ex);
                await SpinnerService.HideSpinnerAsync();
                return;
            }

            if (response.IsSuccessStatusCode)
            {
                await LoginService.Login(await response.Content.ReadAsStringAsync());
            }
            else
            {
                ToastService.ShowExceptionToast(new Exception("Something went wrong. Request was unsuccesfull"));
            }
        }

        private async Task LogInAsync()
        {
            
        }

        private sealed class InputModel
        {
            [Required(ErrorMessage = "Email is required")]
            [CustomValidation(
                validatorType: typeof(EmailVerificationService), 
                method: nameof(EmailVerificationService.IsDomainNameValid))]
            [EmailAddress(ErrorMessage = "This email does not meet the requirements")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Password is required")]
            [DataType(DataType.Password)]
            [RegularExpression(
                pattern: Constants.VALID_PASSWORD_PATTERN,
                ErrorMessage = Constants.PASSWORD_ERROR_MESSAGE)]
            public string Password { get; set; }

            public bool RememberMe { get; set; }
        }
    }
}
