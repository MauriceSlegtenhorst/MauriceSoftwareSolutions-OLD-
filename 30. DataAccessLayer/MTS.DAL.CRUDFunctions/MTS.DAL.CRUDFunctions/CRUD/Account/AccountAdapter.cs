using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using MTS.BL.Infra.APILibrary;
using MTS.Core.GlobalLibrary;
using MTS.Core.GlobalLibrary.Utils;
using MTS.DAL.DatabaseAccess.Utils;
using MTS.DAL.Infra.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace MTS.DAL.DatabaseAccess.CRUD.Account
{
    public sealed class AccountAdapter : IAccountAdapter
    {
        private readonly UserManager<EFUserAccount> _userManager;
        private readonly IEmailSender _emailSender;

        public AccountAdapter(
            UserManager<EFUserAccount> userManager,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        #region Create
        /// <exception cref="System.Exception">Thrown when the UserManager was not able to create the useraccount</exception>
        /// <exception cref="System.ArgumentException">Thrown when one or both of the parameters was null or empty</exception>
        [AllowAnonymous]
        public async Task<UserAccount> CreateByEmailAndPasswordAsync(string email, string password)
        {
            if (String.IsNullOrEmpty(email) || String.IsNullOrEmpty(password))
                throw new ArgumentException("Parameters cannot be null or empty");

            var efUserAccount = new EFUserAccount
            {
                UserName = email,
                Email = email
            };

            IdentityResult result = await _userManager.CreateAsync(efUserAccount, password);

            if (result != null && result.Succeeded)
            {
                await EmailHelper.SendConfirmationEmailAsync(efUserAccount, _userManager, _emailSender);

                var userAccount = new UserAccount();

                efUserAccount = await _userManager.FindByEmailAsync(email);

                PropertyCopier<EFUserAccount, UserAccount>.Copy(efUserAccount, userAccount);

                return userAccount;
            }
            else
            {
                var errors = new string[result.Errors.Count()];
                for (int i = 0; i < errors.Length; i++)
                {
                    errors[i] = result.Errors.ElementAt(i).Description;
                }

                throw new Exception(JsonConvert.SerializeObject(errors));
            }
        }

        /// <exception cref="System.Exception">Thrown when the UserManager was not able to create the useraccount</exception>
        /// <exception cref="System.ArgumentException">Thrown when the UserAccount parameter was null or invalid</exception>
        public async Task<UserAccount> CreateByAccountAsync(UserAccount userAccount)
        {
            if (userAccount == null || String.IsNullOrEmpty(userAccount.Email) || String.IsNullOrEmpty(userAccount.Password) || String.IsNullOrEmpty(userAccount.Id))
                throw new ArgumentException("Parameter cannot be null or ivalid");

            var efUserAccount = new EFUserAccount();
            PropertyCopier<UserAccount, EFUserAccount>.Copy(userAccount, efUserAccount);

            IdentityResult result = await _userManager.CreateAsync(efUserAccount, userAccount.Password);

            if (result != null && result.Succeeded)
            {
                await EmailHelper.SendConfirmationEmailAsync(efUserAccount, _userManager, _emailSender);

                efUserAccount = await _userManager.FindByEmailAsync(userAccount.Email);

                PropertyCopier<EFUserAccount, UserAccount>.Copy(efUserAccount, userAccount);

                return userAccount; 
            }
            else
            {
                var errors = new string[result.Errors.Count()];
                for (int i = 0; i < errors.Length; i++)
                {
                    errors[i] = result.Errors.ElementAt(i).Description;
                }

                throw new Exception(JsonConvert.SerializeObject(errors));
            }
        }
        #endregion

        #region Read
        /// <exception cref="System.ArgumentException">Thrown when the id parameter was null or empty</exception>
        /// <exception cref="System.Exception">Thrown when UserManager could not find any UserAccount with a matching id</exception>
        public async Task<UserAccount> ReadByIdAsync(string id)
        {
            if(String.IsNullOrEmpty(id))
                throw new ArgumentException("Parameters id cannot be null or empty");

            var efUserAccount = await _userManager.FindByIdAsync(id);

            if (efUserAccount != null)
            {
                var userAccount = new UserAccount();

                PropertyCopier<EFUserAccount, UserAccount>.Copy(efUserAccount, userAccount);

                return userAccount;
            }
            else
            {
                throw new Exception("No UserAccount was found matching this id");
            }
        }

        /// <exception cref="System.ArgumentException">Thrown when the email parameter was null or empty</exception>
        /// <exception cref="System.Exception">Thrown when UserManager could not find any UserAccount with a matching email</exception>
        public async Task<UserAccount> ReadByEmailAsync(string email)
        {
            if (String.IsNullOrEmpty(email))
                throw new ArgumentException("Parameters email cannot be null or empty");

            var efUserAccount = await _userManager.FindByIdAsync(email);

            if (efUserAccount != null)
            {
                var userAccount = new UserAccount();

                PropertyCopier<EFUserAccount, UserAccount>.Copy(efUserAccount, userAccount);

                return userAccount;
            }
            else
            {
                throw new Exception("No UserAccount was found matching this email");
            }
        }

        public async Task<IEnumerable<UserAccount>> ReadAllAsync()
        {
            var efUserAccounts = await _userManager.Users.ToArrayAsync();

            int count = efUserAccounts.Count();

            var userAccounts = new UserAccount[count];

            for (int i = 0; i < count; i++)
            {
                userAccounts[i] = new UserAccount();
                PropertyCopier<EFUserAccount, UserAccount>.Copy(efUserAccounts[i], userAccounts[i]);
            }

            return userAccounts.AsEnumerable();
        }
        #endregion

        #region Write
        public async Task<bool> WriteAsync(UserAccount userAccount)
        {
            if (userAccount == null || String.IsNullOrEmpty(userAccount.Email) || String.IsNullOrEmpty(userAccount.Password) || String.IsNullOrEmpty(userAccount.Id))
                throw new ArgumentException("Parameter cannot be null or ivalid");

            var efUserAccount = await _userManager.FindByIdAsync(userAccount.Id);

            if (efUserAccount == null)
                throw new Exception("Ef useraccount was null");

            PropertyCopier<UserAccount, EFUserAccount>.Copy(userAccount, efUserAccount);

            var result = await _userManager.UpdateAsync(efUserAccount);

            if (result == null)
                return false;

            return result.Succeeded;
        }
        #endregion

        #region Delete
        public async Task<bool> DeleteById(string id)
        {
            if (String.IsNullOrEmpty(id))
                throw new ArgumentException("Parameters id cannot be null or empty");

            var efUserAccount = await _userManager.FindByIdAsync(id);

            if (efUserAccount != null)
            {
                var result = await _userManager.DeleteAsync(efUserAccount);

                return result.Succeeded; 
            }
            else
            {
                throw new Exception("No UserAccount was found matching this id");
            }
        }
        #endregion

        // Confirm email
        public async Task<bool> ConfirmEmailAsync(ConfirmEmailHolder confirmEmailHolder)
        {
            var userAccount = await _userManager.FindByIdAsync(confirmEmailHolder.UserId);

            confirmEmailHolder.Code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(confirmEmailHolder.Code));
            var result = await _userManager.ConfirmEmailAsync(userAccount, confirmEmailHolder.Code);

            return result.Succeeded;
        }
    }

}
