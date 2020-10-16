using MTS.PL.Web.Blazor.Client.RazorComponents.Authentication;
using MTS.PL.Web.Blazor.Client.Utils.Services.Dialog;

namespace MTS.PL.Web.Blazor.Client.Pages.Authentication
{
    public partial class TokenExpired
    {
        private void ShowLoginForm()
        {
            var dialogOptions = new DialogOptions
            {
                HasCloseButton = true,
                HasHeader = true,
                Width = "432px",
            };

            _dialogService.Show<LoginComponent>("Please enter your credentials", null, dialogOptions);
        }
    }
}
