using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using MTS.DAL.Infra.APILibrary;
using MTS.Core.GlobalLibrary.Utils;
using MTS.DAL.DatabaseAccess.Utils;
using MTS.DAL.Infra.Entities;
using MTS.DAL.Infra.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MTS.Core.GlobalLibrary.Constants;

namespace MTS.DAL.DatabaseAccess.CRUD.Account
{
    public sealed class AccountAdapter : IAccountAdapter
    {
        private readonly UserManager<EFUserAccount> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSender _emailSender;

        public AccountAdapter(
            UserManager<EFUserAccount> userManager,
            RoleManager<IdentityRole> roleManager,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _emailSender = emailSender;
        }

        #region Create
        /// <exception cref="System.Exception">Thrown when the UserManager was not able to create the useraccount</exception>
        /// <exception cref="System.ArgumentException">Thrown when one or both of the parameters was null or empty</exception>
        [AllowAnonymous]
        public async Task<IEFUserAccount> CreateByEmailAndPasswordAsync(string email, string password)
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

                efUserAccount = await _userManager.FindByEmailAsync(email);

                return efUserAccount;
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
        public async Task<IEFUserAccount> CreateByAccountAsync(UserAccount userAccount)
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

                return efUserAccount; 
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
        public async Task<IEFUserAccount> ReadByIdAsync(string id)
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
        public async Task<IEFUserAccount> ReadByEmailAsync(CredentialHolder credentialHolder)
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

        public Task<IEnumerable<IEFUserAccount>> ReadAllAsync()
        {
            var efUserAccounts = _userManager.Users.AsEnumerable<IEFUserAccount>();

            return Task.FromResult(efUserAccounts);
        }
        #endregion

        #region Write
        public async Task<IdentityResult> WriteAsync(UserAccount userAccount)
        {
            if (userAccount == null || String.IsNullOrEmpty(userAccount.Email) || String.IsNullOrEmpty(userAccount.Password) || String.IsNullOrEmpty(userAccount.Id))
                throw new ArgumentException("Parameter cannot be null or ivalid");

            var efUserAccount = await _userManager.FindByIdAsync(userAccount.Id);

            if (efUserAccount == null)
                throw new Exception("Ef useraccount was null");

            PropertyCopier<UserAccount, EFUserAccount>.Copy(userAccount, efUserAccount);

            return await _userManager.UpdateAsync(efUserAccount);
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

            if(callerAccount.Id != id)
                throw new UnauthorizedAccessException("Caller is not allowed to delete this account");

            var accountToBeDeleted = await _userManager.FindByIdAsync(id);

            if (accountToBeDeleted == null)
                throw new Exception("No UserAccount was found matching this id");

            return await _userManager.DeleteAsync(accountToBeDeleted);
        }
        #endregion

        #region Roles
        public async Task<IdentityResult> AddRolesToAccountAsync(string id, byte roles)
        {
            var accessLevels = (AccessLevel)roles;

            if (String.IsNullOrEmpty(id) || (AccessLevel)roles == AccessLevel.Nonexistent)
                throw new ArgumentException("Parameters are required. Id or roles were null or empty");

            var efUserAccount = await _userManager.FindByIdAsync(id);

            if (efUserAccount == null)
                throw new Exception("Ef useraccount was null");

            IEnumerable<string> rolesEnumerated = accessLevels.ToString().Split(',');

            foreach (var role in rolesEnumerated)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    var roleResult = await _roleManager.CreateAsync(new IdentityRole { Name = role });

                    if (!roleResult.Succeeded)
                    {
                        StringBuilder stringBuilder = new StringBuilder();

                        foreach (var error in roleResult.Errors)
                        {
                            stringBuilder.AppendLine(error.Description);
                        }

                        throw new Exception($"Something went wrong while creating the new role(s). {stringBuilder}");
                    } 
                }
            }

            var result = await _userManager.AddToRolesAsync(efUserAccount, rolesEnumerated);

            return result;
        }

        public async Task<IdentityResult> RemoveRolesFromAccountAsync(string id, byte roles)
        {
            var accessLevels = (AccessLevel)roles;

            if (String.IsNullOrEmpty(id) || (AccessLevel)roles == AccessLevel.Nonexistent)
                throw new ArgumentException("Parameters are required. Id or roles were null or empty");

            var efUserAccount = await _userManager.FindByIdAsync(id);

            if (efUserAccount == null)
                throw new Exception("Ef useraccount was null");

            IEnumerable<string> rolesEnumerated = accessLevels.ToString().Split(',');

            IdentityResult result = await _userManager.RemoveFromRolesAsync(efUserAccount, rolesEnumerated);

            return result;
        }
        #endregion

        // Confirm email
        public async Task<IdentityResult> ConfirmEmailAsync(string id, string code)
        {
            var userAccount = await _userManager.FindByIdAsync(id);

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

            var result = await _userManager.ConfirmEmailAsync(userAccount, code);

            return result;
        }
    }

}
