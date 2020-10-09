using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MTS.Core.GlobalLibrary;
using MTS.PL.Infra.Interfaces.Standard;
using MTS.PL.Web.Blazor.Client.Utils.Services.Dialog;
using MTS.PL.Web.Blazor.Client.Utils.Services.Spinner;
using MTS.PL.Web.Blazor.Client.Utils.Services.Verification;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTS.PL.Web.Blazor.Client.RazorComponents.Registration
{
    public partial class RegisterComponent : IDisposable
    {
        private const string INVISIBLE = "invisible";

        [Inject]
        private IDialogService _dialogService { get; set; }

        [Inject]
        private ILoginService _loginService { get; set; }

        [Inject]
        private ISpinnerService _spinnerService { get; set; }

        private InputModel inputModel;
        private EditContext editContext;
        private string respectableDomains;
        private string emailValidationCss = INVISIBLE;
        private string passwordOneValidationCss = INVISIBLE;
        private string passwordTwoValidationCss = INVISIBLE;
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
                    emailValidationCss = null;

                FieldIdentifier passwordOneField = editContext.Field(nameof(inputModel.PasswordOne));
                if (editContext.GetValidationMessages(passwordOneField).Any())
                    passwordOneValidationCss = null;

                FieldIdentifier passwordTwoField = editContext.Field(nameof(inputModel.PasswordTwo));
                if (editContext.GetValidationMessages(passwordTwoField).Any())
                    passwordTwoValidationCss = null;
            }
        }

        private async Task SubmitAsync()
        {
            await _spinnerService.ShowSpinner("Requesting authorization");


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
            public string PasswordOne { get; set; }

            [Required(ErrorMessage = "Password is required")]
            [DataType(DataType.Password)]
            [RegularExpression(
                pattern: Constants.VALID_PASSWORD_PATTERN,
                ErrorMessage = Constants.PASSWORD_ERROR_MESSAGE)]
            [Compare(nameof(PasswordOne), ErrorMessage = "The two password fields must correspond")]
            public string PasswordTwo { get; set; }

            public bool RememberMe { get; set; }
        }
    }
}
