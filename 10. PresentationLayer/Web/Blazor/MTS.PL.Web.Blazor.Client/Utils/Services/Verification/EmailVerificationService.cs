using MTS.Core.GlobalLibrary;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MTS.PL.Web.Blazor.Client.Utils.Services.Verification
{
    public static class EmailVerificationService
    {
        public static ValidationResult IsDomainNameValid(string email, ValidationContext validationContext)
        {
            for (int i = 0; i < Constants.VALID_EMAIL_DOMAINS.Length; i++)
            {
                if (email.ToString().Contains(Constants.VALID_EMAIL_DOMAINS[i]))
                    return ValidationResult.Success;
            }

            return new ValidationResult("This email domain is not allowed. Please use a respectable domain", new List<string> { validationContext.MemberName });
        }
    }
}
