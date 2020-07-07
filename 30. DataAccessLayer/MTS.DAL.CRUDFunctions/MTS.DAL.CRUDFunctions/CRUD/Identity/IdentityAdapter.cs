using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using MTS.PL.DatabaseAccess.Utils;
using MTS.PL.DatabaseAccess.DataContext;
using MTS.PL.Entities.Core;
using MTS.PL.Infra.Interfaces.Standard.DatabaseAdapter;
using MTS.PL.Infra.Interfaces.Standard;
using MTS.PL.Entities.Standard;

namespace MTS.PL.DatabaseAccess.CRUD.Identity
{
    public sealed class IdentityAdapter : IdentityAdapterHelper, IIdentityAdapter
    {
        private readonly SignInManager<DALUserAccount> _signInManager;
        private readonly UserManager<DALUserAccount> _userManager;
        private readonly DbConfigurations _dbConfigurations;

        public IdentityAdapter(
            SignInManager<DALUserAccount> signInManager,
            UserManager<DALUserAccount> userManager,
            DbConfigurations dbConfigurations) : base(signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _dbConfigurations = dbConfigurations;
        }

        public async Task<IAuthentificationResult> LogIn(ICredentialHolder credentials)
        {
            DALUserAccount efUserAccount = await _userManager.FindByEmailAsync(credentials.Email);

            if (efUserAccount == null)
            {
                return new BLAuthentificationResult { IsSucceeded = false, Errors = new[] { "No user exists with this email and password" } };
            }

            List<string> responses = new List<string>();

            GetEmailConfirmedMessages(efUserAccount, responses);

            GetIsAdmittedMessages(efUserAccount, responses);

            if (responses.Count > 0)
                return new BLAuthentificationResult { IsSucceeded = false, Errors = responses };

            var result = await _signInManager.PasswordSignInAsync(
                credentials.Email,
                credentials.Password,
                isPersistent: credentials.RememberMe,
                lockoutOnFailure: true);

            if (result.Succeeded == false)
            {
                HandleNegativeResult(result, efUserAccount, responses);

                return new BLAuthentificationResult { IsSucceeded = false, Errors = responses };
            }

            try
            {
                var authResult = new BLAuthentificationResult
                {
                    IsSucceeded = true,
                    UserToken = await UserTokenBuilder.BuildToken(efUserAccount, _userManager, _dbConfigurations.IssuerSigningKey)
                };

                return authResult;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> LogOut()
        {
            await _signInManager.SignOutAsync();

            return true;
        }
    }
}
