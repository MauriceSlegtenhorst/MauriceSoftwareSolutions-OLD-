using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using MTS.PL.Infra.Interfaces;
using MTS.Core.GlobalLibrary;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using MTS.PL.Entities.Core;

namespace MTS.PL.DatabaseAccess.Utils
{
    internal static class EmailHelper
    {        // TODO Make callback url redirect to either webpage or mobile depending on what platform was used creating the account
        internal static async Task SendConfirmationEmailAsync(DALUserAccount dalUserAccount, UserManager<DALUserAccount> userManager, IEmailSender emailSender)
        {
            var code = await userManager.GenerateEmailConfirmationTokenAsync(dalUserAccount);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = $"{Constants.BLAZOR_WEB_BASE_ADDRESS}/account/confirmemail/{dalUserAccount.Id}/{code}";

            await emailSender.SendEmailAsync(
                        dalUserAccount.Email,
                        "Confirm your email",
                        $"Welcome to the Maurice Tech Community!\n" +
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
        }
    }
}
