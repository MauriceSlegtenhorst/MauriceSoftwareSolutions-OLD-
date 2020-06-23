using System;

namespace MTS.PL.Infra.InjectionLibrary
{
    public interface IUserAccount
    {
        int AccessFailedCount { get; set; }
        int AccessLevel { get; set; }
        string Affix { get; set; }
        string ConcurrencyStamp { get; set; }
        string Email { get; set; }
        bool EmailConfirmed { get; set; }
        string FirstName { get; set; }
        string Id { get; set; }
        string LastName { get; set; }
        bool LockoutEnabled { get; set; }
        bool IsAdmitted { get; set; }
        DateTimeOffset? LockoutEnd { get; set; }
        string NormalizedEmail { get; set; }
        string NormalizedUserName { get; set; }
        string PasswordHash { get; set; }
        string PhoneNumber { get; set; }
        bool PhoneNumberConfirmed { get; set; }
        string SecurityStamp { get; set; }
        bool TwoFactorEnabled { get; set; }
        string UserName { get; set; }
    }
}