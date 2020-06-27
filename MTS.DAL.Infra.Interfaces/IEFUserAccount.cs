using System;

namespace MTS.DAL.Infra.Interfaces
{
    public interface IEFUserAccount
    {
        int AccessFailedCount { get; set; }
        string Affix { get; set; }
        string ConcurrencyStamp { get; set; }
        string Email { get; set; }
        bool EmailConfirmed { get; set; }
        string FirstName { get; set; }
        string FullName { get; }
        string Id { get; set; }
        bool IsAdmitted { get; set; }
        string LastName { get; set; }
        bool LockoutEnabled { get; set; }
        DateTimeOffset? LockoutEnd { get; set; }
        string NormalizedEmail { get; set; }
        string NormalizedUserName { get; set; }
        string PasswordHash { get; set; }
        string PhoneNumber { get; set; }
        bool PhoneNumberConfirmed { get; set; }
        string SecurityStamp { get; set; }
        bool TwoFactorEnabled { get; set; }
        string UserName { get; set; }

        string ToString();
    }
}