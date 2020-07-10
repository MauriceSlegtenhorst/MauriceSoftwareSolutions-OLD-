using MTS.Core.GlobalLibrary;
using MTS.PL.Infra.Interfaces.Standard;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MTS.PL.Infra.Entities.Standard
{
    public class PLUserAccount : IPLUserAccount
    {
        [Display(Name = "Id", ShortName = "Id")]
        public string Id { get; set; }

        [Display(Name = "Is admitted", ShortName = "Admitted", Description = "True if the user is admitted by an admin, otherwise false.")]
        public bool IsAdmitted { get; set; }

        [Display(Name = "Email confirmed", ShortName = "E. Confirmed", Description = "True if the email address has been confirmed, otherwise false.")]
        public bool EmailConfirmed { get; set; }

        [Display(Name = "Phone number confirmed", ShortName = "P.N. Confirmed", Description = "True if the telephone number has been confirmed, otherwise false.")]
        public bool PhoneNumberConfirmed { get; set; }

        [Display(Name = "Lockout enabled", ShortName = "Lock Enabled", Description = " True if the user could be locked out, otherwise false.")]
        public bool LockoutEnabled { get; set; }

        [Display(Name = "Two factor authentication enabled", ShortName = "2F.A. enabled", Description = "True if 2fa is enabled, otherwise false.")]
        public bool TwoFactorEnabled { get; set; }

        [Display(Name = "Phone number", ShortName = "Phone nr.", Description = "Telephone number of the user")]
        [Phone]
        [StringLength(maximumLength: 10, MinimumLength = 10, ErrorMessage = "Phone number is to short or long")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Password", ShortName = "Password", Description = "Super duper secret password for the user's account")]
        [DataType(DataType.Password)]
        [RegularExpression(Constants.VALID_PASSWORD_PATTERN)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Email", ShortName = "Email", Description = "Email address of the user")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "First name", ShortName = "F. name", Description = "First name of the user")]
        [StringLength(maximumLength: Constants.NAME_MAX_LENGTH, MinimumLength = Constants.NAME_MIN_LENGTH, ErrorMessage = "First name is to short or long")]
        public string FirstName { get; set; }

        [Display(Name = "Affix", ShortName = "Affix", Description = "Affix of the user, a.k.a. the word between your first name and last name if any")]
        [StringLength(maximumLength: Constants.NAME_MAX_LENGTH, MinimumLength = Constants.NAME_MIN_LENGTH, ErrorMessage = "Affix is to short or long")]
        public string Affix { get; set; }

        [Display(Name = "Last name", ShortName = "L. name", Description = "Last name of the user")]
        [StringLength(maximumLength: Constants.NAME_MAX_LENGTH, MinimumLength = Constants.NAME_MIN_LENGTH, ErrorMessage = "Last name is to short or long")]
        public string LastName { get; set; }

        public string FullName 
        { 
            get 
            {
                if (String.IsNullOrEmpty(FirstName) && String.IsNullOrEmpty(LastName))
                    return null;

                var stringBuilder = new StringBuilder();

                if (String.IsNullOrEmpty(FirstName) == false)
                    stringBuilder.Append(FirstName);    

                if (String.IsNullOrEmpty(Affix) == false)
                    stringBuilder.Append($" {Affix}");

                if (String.IsNullOrEmpty(LastName) == false)
                    stringBuilder.Append($" {LastName}");

                return stringBuilder.ToString();
            } 
        }

        [Display(Name = "Access fail count", ShortName = "Access fails", Description = "Times someone tried to login into this account and failed")]
        public int AccessFailedCount { get; set; }

        [Display(Name = "Lockout end", ShortName = "Lock end", Description = "Offset untill an account is locked")]
        public DateTimeOffset? LockoutEnd { get; set; }
    }
}
