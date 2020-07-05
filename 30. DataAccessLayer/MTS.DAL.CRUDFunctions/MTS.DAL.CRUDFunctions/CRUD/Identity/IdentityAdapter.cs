using Microsoft.AspNetCore.Identity;
using MTS.DAL.Infra.APILibrary;
using MTS.DAL.Infra.Entities;
using MTS.DAL.Infra.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using MTS.DAL.DatabaseAccess.Utils;
using MTS.DAL.DatabaseAccess.DataContext;

namespace MTS.DAL.DatabaseAccess.CRUD.Identity
{
    public sealed class IdentityAdapter : IIdentityAdapter
    {
        private readonly SignInManager<EFUserAccount> _signInManager;
        private readonly UserManager<EFUserAccount> _userManager;
        private readonly DbConfigurations _dbConfigurations;

        public IdentityAdapter(
            SignInManager<EFUserAccount> signInManager,
            UserManager<EFUserAccount> userManager,
            DbConfigurations dbConfigurations)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _dbConfigurations = dbConfigurations;
        }

        public async Task<AuthentificationResult> LogIn(CredentialHolder credentials)
        {
            EFUserAccount efUserAccount = await _userManager.FindByEmailAsync(credentials.Email);

            if (efUserAccount == null)
            {
                return new AuthentificationResult { IsSucceeded = false, Errors = new[] { "No user exists with this email and password" } };
            }

            List<string> responses = new List<string>();

            if (!efUserAccount.EmailConfirmed)
                responses.Add("Email not yet confirmed by user");

            if (!efUserAccount.IsAdmitted)
                responses.Add("Email not yet confirmed by admin");

            if (responses.Count > 0)
                return new AuthentificationResult { IsSucceeded = false, Errors = responses };

            var result = await _signInManager.PasswordSignInAsync(
                credentials.Email,
                credentials.Password,
                isPersistent: credentials.RememberMe,
                lockoutOnFailure: true);

            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                    responses.Add($"User is now locked out for some time");

                if (result.IsNotAllowed)
                    responses.Add($"You are not allowed to login for some time");

                if (responses.Count == 0)
                    responses.Add("Wrong password");

                responses.Add($"Login attempts remaining: { _signInManager.Options.Lockout.MaxFailedAccessAttempts - efUserAccount.AccessFailedCount }");

                return new AuthentificationResult { IsSucceeded = false, Errors = responses };
            }

            return new AuthentificationResult
            {
                IsSucceeded = true,
                UserToken = await UserTokenBuilder.BuildToken(efUserAccount, _userManager, _dbConfigurations.IssuerSigningKey)
            };
        }

        public async Task<bool> LogOut()
        {
            await _signInManager.SignOutAsync();

            return true;
        }
    }
}
