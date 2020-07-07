using System;
using static MTS.Core.GlobalLibrary.Constants;

namespace MTS.PL.Infra.InjectionLibrary
{
    public interface IUserAccount
    {
        string Id { get; set; }

        bool IsAdmitted { get; set; }

        bool EmailConfirmed { get; set; }

        bool PhoneNumberConfirmed { get; set; }

        string PhoneNumber { get; set; }

        bool LockoutEnabled { get; set; }

        string Password { get; set; }

        string Email { get; set; }

        string FirstName { get; set; }

        string Affix { get; set; }

        string LastName { get; set; }

        int AccessFailedCount { get; set; }

        DateTimeOffset? LockoutEnd { get; set; }

        bool TwoFactorEnabled { get; set; }
    }
}