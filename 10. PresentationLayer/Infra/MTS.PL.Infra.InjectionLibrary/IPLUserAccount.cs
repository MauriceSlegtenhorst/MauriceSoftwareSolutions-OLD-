using System;

namespace MTS.PL.Infra.Interfaces.Standard
{
    public interface IPLUserAccount
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

        string FullName { get; }

        int AccessFailedCount { get; set; }

        DateTimeOffset? LockoutEnd { get; set; }

        bool TwoFactorEnabled { get; set; }

        DateTime? LockoutEndDateTime { get; set; }
    }
}