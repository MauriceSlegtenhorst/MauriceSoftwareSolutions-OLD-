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
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MTS.PL.Web.Blazor.Client.RazorComponents.Registration
{
    public partial class RegisterComponent : IDisposable
    {
        private const string INVISIBLE = "invisible";
        private const string BORDER_PRIMARY = "border-primary";

        [Inject]
        private IDialogService _dialogService { get; set; }

        [Inject] 
        private IToastService _toastService { get; set; }

        [Inject]
        private ILoginService _loginService { get; set; }

        [Inject]
        private ISpinnerService _spinnerService { get; set; }

        [Inject] 
        private IHttpClientFactory _httpClientFactory { get; set; }

        [Inject]
        private NavigationManager _navigationManager { get; set; }

        private InputModel inputModel;
        private EditContext editContext;
        private string emailValidationCss = INVISIBLE;      
        private string passwordOneValidationCss = INVISIBLE;
        private string passwordTwoValidationCss = INVISIBLE;
        private string emailTextBoxWorkAroundCss = BORDER_PRIMARY;
        private string passwordOneTextBoxWorkAroundCss = BORDER_PRIMARY;
        private string passwordTwoTextBoxWorkAroundCss = BORDER_PRIMARY;
        private bool showPassword;
        private bool canSubmit;

        protected override void OnInitialized()
        {
            inputModel = new InputModel();

            editContext = new EditContext(inputModel);

            editContext.OnValidationStateChanged += OnValidationStateChanged;

            base.OnInitialized();
        }

        public void Dispose()
        {
            editContext.OnValidationStateChanged -= OnValidationStateChanged;
        }

        // Because of a bug with the Syncfusions textbox component initiating with the e-success css I had to implement a temporary workaround. Could not find a better way than this at the moment. It's ugly I know.
        private void OnValidationStateChanged(object sender, ValidationStateChangedEventArgs eventArgs)
        {
            if (editContext.GetValidationMessages().Any() == false)
            {
                canSubmit = true;
                emailValidationCss = INVISIBLE;
                passwordOneValidationCss = INVISIBLE;
                passwordTwoValidationCss = INVISIBLE;
                emailTextBoxWorkAroundCss = BORDER_PRIMARY;
                passwordOneTextBoxWorkAroundCss = BORDER_PRIMARY;
                passwordTwoTextBoxWorkAroundCss = BORDER_PRIMARY;
            }
            else
            {
                canSubmit = false;

                FieldIdentifier emailField = editContext.Field(nameof(inputModel.Email));
                if (editContext.GetValidationMessages(emailField).Any())
                {
                    emailValidationCss = null;
                    emailTextBoxWorkAroundCss = null;
                }

                FieldIdentifier passwordOneField = editContext.Field(nameof(inputModel.Password));
                if (editContext.GetValidationMessages(passwordOneField).Any())
                {
                    passwordOneValidationCss = null;
                    passwordOneTextBoxWorkAroundCss = null;
                }   

                FieldIdentifier passwordTwoField = editContext.Field(nameof(inputModel.PasswordTwo));
                if (editContext.GetValidationMessages(passwordTwoField).Any())
                {
                    passwordTwoValidationCss = null;
                    passwordTwoTextBoxWorkAroundCss = null;
                }
            }
        }

        private async Task SubmitAsync()
        {
            await _spinnerService.ShowSpinnerAsync("Requesting authorization...");

            string requestUrl = $"{Constants.APIControllers.ACCOUNT}/{Constants.AccountControllerEndpoints.CREATE_BY_CREDENTIALS}";

            HttpResponseMessage responseMessage;

            try
            {
                responseMessage = await _httpClientFactory.CreateClient(BlazorConstants.HttpClients.API).PutAsJsonAsync(requestUrl, inputModel);
            }
            catch (Exception ex)
            {
                await _spinnerService.HideSpinnerAsync();

                _toastService.ShowExceptionToast(ex);
                
                return;
            }

            await _spinnerService.SetSpinnerLabelAsync("Processing response...");

            if (responseMessage.IsSuccessStatusCode)
            {
                _toastService.ShowSuccessToast($"Registration for {inputModel.Email} has been received.");
                _navigationManager.NavigateTo("/account/accountsubmitted");
            }
            else
            {
                _toastService.ShowExceptionToast(new Exception(await responseMessage.Content.ReadAsStringAsync()));
            }

            await _spinnerService.HideSpinnerAsync();
        }

        public sealed class InputModel
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

            [JsonIgnore]
            [Required(ErrorMessage = "Password is required")]
            [DataType(DataType.Password)]
            [RegularExpression(
                pattern: Constants.VALID_PASSWORD_PATTERN,
                ErrorMessage = Constants.PASSWORD_ERROR_MESSAGE)]
            [Compare(nameof(Password), ErrorMessage = "The two password fields must correspond")]
            public string PasswordTwo { get; set; }

            public bool RememberMe { get; set; }
        }
    }
}
