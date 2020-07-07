using Microsoft.AspNetCore.Identity;
using MTS.PL.Entities.Core;
using System.Collections.Generic;

namespace MTS.PL.DatabaseAccess.CRUD.Identity
{
    public class IdentityAdapterHelper
    {
        private readonly SignInManager<DALUserAccount> _signInManager;

        protected IdentityAdapterHelper(SignInManager<DALUserAccount> signInManager)
        {
            _signInManager = signInManager;
        }

        protected void HandleNegativeResult(SignInResult result, DALUserAccount efUserAccount, List<string> responses)
        {
            if (result.IsLockedOut == true)
                responses.Add($"User is now locked out for some time");

            if (result.IsNotAllowed == true)
                responses.Add($"You are not allowed to login for some time");

            if (responses.Count == 0)
                responses.Add("Wrong password");

            responses.Add($"Login attempts remaining: { _signInManager.Options.Lockout.MaxFailedAccessAttempts - efUserAccount.AccessFailedCount }");
        }

        protected void GetIsAdmittedMessages(DALUserAccount efUserAccount, List<string> responses)
        {
            if (efUserAccount.IsAdmitted == false)
                responses.Add("Email not yet confirmed by admin");
        }

        protected void GetEmailConfirmedMessages(DALUserAccount efUserAccount, List<string> responses)
        {
            if (efUserAccount.EmailConfirmed == false)
                responses.Add("Email not yet confirmed by user");
        }
    }
}
