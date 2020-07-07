using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using MTS.PL.DatabaseAccess.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MTS.PL.Entities.Core;
using MTS.PL.Interfaces.Standard;
using MTS.Core.GlobalLibrary.Utils;
using MTS.Core.GlobalLibrary;
using MTS.PL.Infra.Interfaces;
using MTS.PL.Infra.Interfaces.Standard;
using MTS.PL.Infra.Interfaces.Standard.DatabaseAdapter;
using MTS.PL.Entities.Standard;
using MTS.PL.Infra.Interfaces.Standard;
using MTS.PL.Infra.Entities.Standard;

namespace MTS.PL.DatabaseAccess.CRUD.Account
{
    public sealed class AccountAdapter : IAccountAdapter
    {
        private readonly UserManager<DALUserAccount> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSender _emailSender;
        private readonly ISeedData _seedData;

        public AccountAdapter(
            UserManager<DALUserAccount> userManager,
            RoleManager<IdentityRole> roleManager,
            IEmailSender emailSender,
            ISeedData seedData)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _emailSender = emailSender;
            _seedData = seedData;
        }

        #region Create
        /// <exception cref="System.Exception">Thrown when the UserManager was not able to create the useraccount</exception>
        /// <exception cref="System.ArgumentException">Thrown when one or both of the parameters was null or empty</exception>
        public async Task<IBLUserAccount> CreateByEmailAndPasswordAsync(string email, string password)
        {
            await EnsureDefaultAccountsExists();

            if (String.IsNullOrEmpty(email) || String.IsNullOrEmpty(password))
                throw new ArgumentException("Parameters cannot be null or empty");

            var dlUserAccount = new DALUserAccount
            {
                UserName = email,
                Email = email
            };

            IdentityResult result = await _userManager.CreateAsync(dlUserAccount, password);

            if (result != null && result.Succeeded)
            {
                await EmailHelper.SendConfirmationEmailAsync(dlUserAccount, _userManager, _emailSender);

                dlUserAccount = await _userManager.FindByEmailAsync(email);

                return dlUserAccount;
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
            if (blUserAccount == null || String.IsNullOrEmpty(blUserAccount.Email) || String.IsNullOrEmpty(blUserAccount.Password) || String.IsNullOrEmpty(blUserAccount.Id))
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

            if(callerAccount.Id != id)
                throw new UnauthorizedAccessException("Caller is not allowed to delete this account");

            var accountToBeDeleted = await _userManager.FindByIdAsync(id);

            if (accountToBeDeleted == null)
                throw new Exception("No UserAccount was found matching this id");

            return await _userManager.DeleteAsync(accountToBeDeleted);
        }
        #endregion

        #region Roles
        public async Task<IdentityResult> AddRolesToAccountAsync(string id, Constants.Roles roles)
        {
            var accessLevels = (Constants.Roles)roles;

            if (String.IsNullOrEmpty(id) || (Constants.Roles)roles == Constants.Roles.Nonexistent)
                throw new ArgumentException("Parameters are required. Id or roles were null or empty");

            var dalUserAccount = await _userManager.FindByIdAsync(id);

            if (dalUserAccount == null)
                throw new Exception("Ef useraccount was null");

            IEnumerable<string> rolesEnumerated = accessLevels.ToString().Split(',');

            foreach (var role in rolesEnumerated)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    var roleResult = await _roleManager.CreateAsync(new IdentityRole { Name = role });

                    if (roleResult.Succeeded == false)
                    {
                        var stringBuilder = new StringBuilder();

                        foreach (var error in roleResult.Errors)
                        {
                            stringBuilder.AppendLine(error.Description);
                        }

                        throw new Exception($"Something went wrong while creating the new role(s). {stringBuilder}");
                    } 
                }
            }

            var result = await _userManager.AddToRolesAsync(dalUserAccount, rolesEnumerated);

            return result;
        }

        public async Task<IdentityResult> RemoveRolesFromAccountAsync(string id, Constants.Roles roles)
        {
            var accessLevels = (Constants.Roles)roles;

            if (String.IsNullOrEmpty(id) || (Constants.Roles)roles == Constants.Roles.Nonexistent)
                throw new ArgumentException("Parameters are required. Id or roles were null or empty");

            var efUserAccount = await _userManager.FindByIdAsync(id);

            if (efUserAccount == null)
                throw new Exception("DALUserAccount was null");

            IEnumerable<string> rolesEnumerated = accessLevels.ToString().Split(',');

            IdentityResult result = await _userManager.RemoveFromRolesAsync(efUserAccount, rolesEnumerated);

            return result;
        }
        #endregion

        public async Task<IdentityResult> ConfirmEmailAsync(string id, string code)
        {
            var dalUserAccount = await _userManager.FindByIdAsync(id);

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

            var result = await _userManager.ConfirmEmailAsync(dalUserAccount, code);

            return result;
        }

        private async Task EnsureDefaultAccountsExists()
        {
            if (await _userManager.Users.AnyAsync() == true)
                return;
            
            var accountsToAdd = await _seedData.GetDefaultAccountsSeedDataAsync();

            foreach (var account in accountsToAdd)
            {
                IdentityResult createAccountResult;

                try
                {
                    createAccountResult = await _userManager.CreateAsync((DALUserAccount)account, "MTS1991password!");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Something went wrong while creating the account for {account.Email}.", ex);
                }

                if (createAccountResult.Succeeded == false)
                    throw new Exception($"Something went wrong while creating {account.Email} account.");

                if (account.Email == "mauricetechsolution@outlook.com")
                {
                    var accountWithId = await _userManager.FindByEmailAsync(account.Email);

                    if (accountWithId == null)
                        throw new NullReferenceException("AccountWithId was null");

                    bool roleResult = false;

                    try
                    {
                        bool adminRoleExists = await _roleManager.RoleExistsAsync(Constants.Security.ADMINISTRATOR);

                        if (adminRoleExists == false)
                        {
                            var createRoleResult = await _roleManager.CreateAsync(new IdentityRole(Constants.Security.ADMINISTRATOR));

                            adminRoleExists = createRoleResult.Succeeded;
                        }

                        if (adminRoleExists)
                        {
                            var addRoleResult = await _userManager.AddToRoleAsync(accountWithId, Constants.Security.ADMINISTRATOR);

                            roleResult = addRoleResult.Succeeded;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Something went wrong while adding a role to the {account.Email} account.", ex);
                    }

                    if(roleResult == false)
                        throw new Exception($"Something went wrong while adding a role to the {account.Email} account.");

                }
            }
        }
    }

}
