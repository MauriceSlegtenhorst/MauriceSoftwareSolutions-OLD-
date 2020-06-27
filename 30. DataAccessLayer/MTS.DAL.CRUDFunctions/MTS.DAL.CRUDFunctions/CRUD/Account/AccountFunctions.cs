using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using MTS.BL.Infra.APILibrary;
using MTS.Core.GlobalLibrary;
using MTS.Core.GlobalLibrary.Utils;
using MTS.DAL.Infra.Interfaces;
using System;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace MTS.DAL.DatabaseAccess.CRUD.Account
{
    public sealed class AccountFunctions : IAccountFunctions
    {
        private readonly UserManager<EFUserAccount> _userManager;
        private readonly IEmailSender _emailSender;

        public AccountFunctions(
            UserManager<EFUserAccount> userManager,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        #region Create
        public async Task<IEFUserAccount> Create(string email, string password)
        {
            var efUserAccount = new EFUserAccount
            {
                UserName = email,
                Email = email
            };

            IdentityResult result = await _userManager.CreateAsync(efUserAccount, password);

            if (result != null && result.Succeeded)
            {
                await SendConfirmationEmail(efUserAccount);

                return await _userManager.FindByEmailAsync(email);
            }
            else
            {
                var errors = new string[result.Errors.Count()];
                for (int i = 0; i < errors.Length; i++)
                {
                    errors[i] = result.Errors.ElementAt(i).Description;
                }

                throw new Exception(errors.ToString());
            }
        }

        public async Task<IEFUserAccount> Create(UserAccount userAccount)
        {
            var efUserAccount = new EFUserAccount();
            PropertyCopier<UserAccount, EFUserAccount>.Copy(userAccount, efUserAccount);

            IdentityResult result = await _userManager.CreateAsync(efUserAccount, userAccount.Password);
            if (result != null && result.Succeeded)
            {
                await SendConfirmationEmail(efUserAccount);

                return await _userManager.FindByEmailAsync(userAccount.Email);
            }
            else
            {
                var errors = new string[result.Errors.Count()];
                for (int i = 0; i < errors.Length; i++)
                {
                    errors[i] = result.Errors.ElementAt(i).Description;
                }

                throw new Exception(errors.ToString());
            }
        }

        private async Task SendConfirmationEmail(EFUserAccount efUserAccount)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(efUserAccount);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = $"{Constants.BLAZOR_WEB_BASE_ADDRESS}/account/confirmemail/{efUserAccount.Id}/{code}";

            await _emailSender.SendEmailAsync(
                        efUserAccount.Email,
                        "Confirm your email",
                        $"Welcome to the Maurice Tech Community!\n" +
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
        }
        #endregion

        #region Read

        #endregion

        #region Write

        #endregion

        #region Delete

        #endregion
    }

}
