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

        [Inject]
        private IDialogService DialogService { get; set; }

        [Inject] 
        private IToastService ToastService { get; set; }

        [Inject]
        private ILoginService LoginService { get; set; }

        [Inject]
        private ISpinnerService SpinnerService { get; set; }

        [Inject] 
        private IHttpClientFactory HttpClientFactory { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        private InputModel inputModel;
        private EditContext editContext;
        private string emailValidationCss = INVISIBLE;      
        private string passwordOneValidationCss = INVISIBLE;
        private string passwordTwoValidationCss = INVISIBLE;
        private bool showPassword;
        private bool canSubmit;
        private bool isSubmitting;
        private string spinnerLabel;

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
            }
            else
            {
                canSubmit = false;

                FieldIdentifier emailField = editContext.Field(nameof(inputModel.Email));
                if (editContext.GetValidationMessages(emailField).Any())
                {
                    emailValidationCss = null;
                }

                FieldIdentifier passwordOneField = editContext.Field(nameof(inputModel.Password));
                if (editContext.GetValidationMessages(passwordOneField).Any())
                {
                    passwordOneValidationCss = null;
                }   

                FieldIdentifier passwordTwoField = editContext.Field(nameof(inputModel.PasswordTwo));
                if (editContext.GetValidationMessages(passwordTwoField).Any())
                {
                    passwordTwoValidationCss = null;
                }
            }
        }

        private async Task SubmitAsync()
        {
            isSubmitting = true;

            string requestUrl = $"{Constants.APIControllers.ACCOUNT}/{Constants.AccountControllerEndpoints.CREATE_BY_CREDENTIALS}";

            HttpResponseMessage responseMessage;

            spinnerLabel = "Registering...";

            try
            {
                responseMessage = await HttpClientFactory.CreateClient(BlazorConstants.HttpClients.API).PutAsJsonAsync(requestUrl, inputModel);
            }
            catch (Exception ex)
            {
                ToastService.ShowExceptionToast(ex);
                isSubmitting = false;
                spinnerLabel = null;
                return;
            }

            spinnerLabel = "Processing response...";

            string responseString = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessage.IsSuccessStatusCode)
            {
                DialogService.Close(DialogResult.Ok($"Registration for {inputModel.Email} has been received and is being processed."));
                ToastService.ShowSuccessToast($"Registration for {inputModel.Email} has been received and is being processed.");
                NavigationManager.NavigateTo("/account/register/accountverification");
            }
            else
            {
                DialogService.Close(DialogResult.Ok(responseString));
                ToastService.ShowExceptionToast(new Exception(await responseMessage.Content.ReadAsStringAsync()));
            }

            isSubmitting = false;
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
