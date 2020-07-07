using MTS.PL.Infra.InjectionLibrary;
using System;
using static MTS.Core.GlobalLibrary.Constants;

namespace MTS.PL.Infra.BlazorLibrary
{
    public class UserAccount : IUserAccount
    {
        public string Id { get; set; }
        public bool IsAdmitted { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool LockoutEnabled { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Affix { get; set; }
        public string LastName { get; set; }
        public int AccessFailedCount { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
    }
}
