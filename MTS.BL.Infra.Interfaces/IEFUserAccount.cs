using System;

namespace MTS.BL.Infra.Interfaces.Core
{
    public interface IEFUserAccount
    {
        string Id { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string Affix { get; set; }
        string LastName { get; set; }
        string UserName { get; set; }
        string PasswordHash { get; set; }
        string PhoneNumber { get; set; }
        bool IsAdmitted { get; set; }
        bool EmailConfirmed { get; set; }
        int AccessFailedCount { get; set; }
        bool LockoutEnabled { get; set; }
        DateTimeOffset? LockoutEnd { get; set; }
        string NormalizedEmail { get; set; }
        string NormalizedUserName { get; set; }
        bool PhoneNumberConfirmed { get; set; }
        string ConcurrencyStamp { get; set; }
        string SecurityStamp { get; set; }
        bool TwoFactorEnabled { get; set; }
    }
}