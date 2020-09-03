using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using MTS.Core.GlobalLibrary;
using MTS.DAL.Entities.Core;
using MTS.DAL.Interfaces.Standard;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MTS.DAL.DatabaseAccess.CRUD.Account
{
    public abstract class AccountAdapterHelper
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<DALUserAccount> _userManager;
        private readonly ISeedData _seedData;

        protected AccountAdapterHelper(RoleManager<IdentityRole> roleManager, UserManager<DALUserAccount> userManager, ISeedData seedData)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _seedData = seedData;
        }

        #region Roles
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.ArgumentException">Thrown when the parameter was null or invalid</exception>
        public async Task<IdentityResult> AddRolesToAccountAsync(string id, Constants.Roles roles)
        {
            var accessLevels = roles;

            if (String.IsNullOrEmpty(id) || roles == Constants.Roles.Nonexistent)
                throw new ArgumentException("Parameters are required. Id or roles were null or empty");

            var dalUserAccount = await _userManager.FindByIdAsync(id);

            if (dalUserAccount == null)
                throw new Exception("Ef useraccount was null");

            IEnumerable<string> rolesEnumerated = accessLevels.ToString().ToLower().Split(',');

            foreach (var role in rolesEnumerated)
            {
                if (await _roleManager.RoleExistsAsync(role) ==  false)
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

        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.ArgumentException">Thrown when the parameter was null or invalid</exception>
        public async Task<IdentityResult> RemoveRolesFromAccountAsync(string id, Constants.Roles roles)
        {
            var accessLevels = roles;

            if (String.IsNullOrEmpty(id) || roles == Constants.Roles.Nonexistent)
                throw new ArgumentException("Parameters are required. Id or roles were null or empty");

            var efUserAccount = await _userManager.FindByIdAsync(id);

            if (efUserAccount == null)
                throw new Exception("DALUserAccount was null");

            IEnumerable<string> rolesEnumerated = accessLevels.ToString().Split(',');

            IdentityResult result = await _userManager.RemoveFromRolesAsync(efUserAccount, rolesEnumerated);

            return result;
        }
        #endregion

        #region Email
        public async Task<IdentityResult> ConfirmEmailAsync(string id, string code)
        {
            var dalUserAccount = await _userManager.FindByIdAsync(id);

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

            var result = await _userManager.ConfirmEmailAsync(dalUserAccount, code);

            return result;
        }
        #endregion

        #region SetupDefaultAccounts
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.NullReferenceException">Thrown when the user manager could not find anyone with the given email address</exception>
        /// <exception cref="System.ArgumentException">Thrown when the parameter was null or invalid</exception>
        public async Task EnsureDefaultAccountsExists()
        {
            if (await _userManager.Users.AnyAsync() == true)
                return;

            var accountsToAdd = await _seedData.GetDefaultAccountsSeedDataAsync();

            foreach (var account in accountsToAdd)
            {
                IdentityResult createAccountResult;

                try
                {
                    // TODO Set this in EnviromentVariables instead of hardcoded
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

                    await AddRolesToAccountAsync(accountWithId.Id, Constants.Roles.Administrator);
                }
            }
        }
        #endregion
    }
}
