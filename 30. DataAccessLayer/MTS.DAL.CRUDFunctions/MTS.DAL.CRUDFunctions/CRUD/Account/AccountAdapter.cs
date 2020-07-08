using Microsoft.AspNetCore.Identity;
using MTS.PL.DatabaseAccess.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MTS.PL.Interfaces.Standard;
using MTS.Core.GlobalLibrary.Utils;
using MTS.Core.GlobalLibrary;
using MTS.PL.Infra.Interfaces;
using MTS.PL.Infra.Interfaces.Standard;
using MTS.PL.Infra.Interfaces.Standard.DatabaseAdapter;
using MTS.PL.Infra.Entities.Standard;
using MTS.PL.Entities.Core;

namespace MTS.PL.DatabaseAccess.CRUD.Account
{
    public sealed class AccountAdapter : AccountAdapterHelper, IAccountAdapter
    {
        private readonly UserManager<DALUserAccount> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSender _emailSender;

        public AccountAdapter(
            UserManager<DALUserAccount> userManager,
            RoleManager<IdentityRole> roleManager,
            IEmailSender emailSender,
            ISeedData seedData) : 
            base(roleManager, userManager, seedData)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _emailSender = emailSender;
        }

        #region Create
        /// <exception cref="System.Exception">Thrown when the UserManager was not able to create the useraccount</exception>
        /// <exception cref="System.ArgumentException">Thrown when one or both of the parameters was null or empty</exception>
        public async Task<IBLUserAccount> CreateByEmailAndPasswordAsync(string email, string password)
        {
#if DEBUG
            // TODO Do this somewhere else when the program starts
            await EnsureDefaultAccountsExists();
#endif

            if (String.IsNullOrEmpty(email) || String.IsNullOrEmpty(password))
                throw new ArgumentException("Parameters cannot be null or empty");

            var dalUserAccount = new DALUserAccount
            {
                UserName = email,
                Email = email
            };

            IdentityResult result = await _userManager.CreateAsync(dalUserAccount, password);

            if (result.Succeeded == false)
            {
                var errors = new string[result.Errors.Count()];
                for (int i = 0; i < errors.Length; i++)
                {
                    errors[i] = result.Errors.ElementAt(i).Description;
                }

                throw new Exception(JsonConvert.SerializeObject(errors));
            }

            await EmailHelper.SendConfirmationEmailAsync(dalUserAccount, _userManager, _emailSender);

            dalUserAccount = await _userManager.FindByEmailAsync(email);

            await AddRolesToAccountAsync(dalUserAccount.Id, Constants.Roles.StandardUser);

            return dalUserAccount;
        }

        /// <exception cref="System.Exception">Thrown when the UserManager was not able to create the useraccount</exception>
        /// <exception cref="System.ArgumentException">Thrown when the UserAccount parameter was null or invalid</exception>
        public async Task<IBLUserAccount> CreateByAccountAsync(IPLUserAccount userAccount)
        {
            if (userAccount == null || String.IsNullOrEmpty(userAccount.Email) || String.IsNullOrEmpty(userAccount.Password) || String.IsNullOrEmpty(userAccount.Id))
                throw new ArgumentException("Parameter cannot be null or ivalid");

            var dalUserAccount = new DALUserAccount();

            PropertyCopier<PLUserAccount, DALUserAccount>.Copy((PLUserAccount)userAccount, dalUserAccount);

            IdentityResult result = await _userManager.CreateAsync(dalUserAccount, userAccount.Password);

            if (result != null && result.Succeeded)
            {
                await EmailHelper.SendConfirmationEmailAsync(dalUserAccount, _userManager, _emailSender);

                dalUserAccount = await _userManager.FindByEmailAsync(userAccount.Email);

                return dalUserAccount; 
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
        public async Task<IBLUserAccount> ReadByIdAsync(string id)
        {
            if(String.IsNullOrEmpty(id))
                throw new ArgumentException("Parameters id cannot be null or empty");

            var efUserAccount = await _userManager.FindByIdAsync(id);

            if (efUserAccount != null)
            {
                return efUserAccount;
            }
            else
            {
                throw new Exception("No UserAccount was found matching this id");
            }
        }

        /// <exception cref="System.ArgumentException">Thrown when the email parameter was null or empty</exception>
        /// <exception cref="System.Exception">Thrown when UserManager could not find any UserAccount with a matching email</exception>
        public async Task<IBLUserAccount> ReadByEmailAsync(ICredentialHolder credentialHolder)
        {
            if (String.IsNullOrEmpty(credentialHolder.Email))
                throw new ArgumentException("Parameters email cannot be null or empty");

            if (String.IsNullOrEmpty(credentialHolder.Password))
                throw new ArgumentException("Parameters password cannot be null or empty");

            var efUserAccount = await _userManager.FindByIdAsync(credentialHolder.Email);

            if (efUserAccount != null)
                throw new Exception("No UserAccount was found matching this email");

            if (!await _userManager.CheckPasswordAsync(efUserAccount, credentialHolder.Password))
                throw new Exception("Wrong password");

            return efUserAccount;
        }

        public Task<IEnumerable<IBLUserAccount>> ReadAllAsync()
        {
            var efUserAccounts = _userManager.Users.AsEnumerable<IBLUserAccount>();

            return Task.FromResult(efUserAccounts);
        }
        #endregion

        #region Write
        public async Task<IdentityResult> WriteAsync(IPLUserAccount blUserAccount)
        {
            if (blUserAccount == null || String.IsNullOrEmpty(blUserAccount.Email) || String.IsNullOrEmpty(blUserAccount.Id))
                throw new ArgumentException("Parameter cannot be null or ivalid");

            var dalUserAccount = await _userManager.FindByIdAsync(blUserAccount.Id);

            if (dalUserAccount == null)
                throw new Exception("Ef useraccount was null");

            PropertyCopier<PLUserAccount, DALUserAccount>.Copy((PLUserAccount)blUserAccount, dalUserAccount);

            return await _userManager.UpdateAsync(dalUserAccount);
        }
        #endregion

        #region Delete
        public async Task<IdentityResult> DeleteByIdAsync(string id, string callerEmail)
        {
            if (String.IsNullOrEmpty(id))
                throw new ArgumentException("Parameters id cannot be null or empty");

            var callerAccount = await _userManager.FindByEmailAsync(callerEmail);

            if(callerAccount == null)
                throw new Exception("No UserAccount was found matching this email");

            var isAllowedByRole = await _userManager.IsInRoleAsync(callerAccount, Constants.Security.ADMINISTRATOR);

            if (callerAccount.Id != id && isAllowedByRole == false)
                throw new UnauthorizedAccessException("Caller is not allowed to delete this account");

            var accountToBeDeleted = await _userManager.FindByIdAsync(id);

            if (accountToBeDeleted == null)
                throw new Exception("No UserAccount was found matching this id");

            return await _userManager.DeleteAsync(accountToBeDeleted);
        }
        #endregion
    }

}
