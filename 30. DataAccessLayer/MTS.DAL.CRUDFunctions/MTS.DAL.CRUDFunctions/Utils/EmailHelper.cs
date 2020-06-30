using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using MTS.Core.GlobalLibrary;
using MTS.DAL.Infra.Interfaces;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace MTS.DAL.DatabaseAccess.Utils
{
    internal static class EmailHelper
    {        // TODO Make callback url redirect to either webpage or mobile depending on what platform was used creating the account
        internal static async Task SendConfirmationEmailAsync(EFUserAccount efUserAccount, UserManager<EFUserAccount> userManager, IEmailSender emailSender)
        {
            var code = await userManager.GenerateEmailConfirmationTokenAsync(efUserAccount);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = $"{Constants.BLAZOR_WEB_BASE_ADDRESS}/account/confirmemail/{efUserAccount.Id}/{code}";

            await emailSender.SendEmailAsync(
                        efUserAccount.Email,
                        "Confirm your email",
                        $"Welcome to the Maurice Tech Community!\n" +
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
        }
    }
}
