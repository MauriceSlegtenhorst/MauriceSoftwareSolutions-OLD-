using MTS.Core.GlobalLibrary;
using Syncfusion.Blazor.Inputs;
using System.ComponentModel.DataAnnotations;

namespace MTS.PL.Web.Blazor.Client.RazorComponents.Authentication
{
    public partial class LoginComponent
    {
        private InputModel inputModel;
        private string emailCss = "";
        private string passwordCss = "";
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
            base.OnInitialized();
        }

        private sealed class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [RegularExpression(
                pattern: Constants.VALID_PASSWORD_PATTERN,
                ErrorMessage = Constants.PASSWORD_ERROR_MESSAGE)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }
    }
}
