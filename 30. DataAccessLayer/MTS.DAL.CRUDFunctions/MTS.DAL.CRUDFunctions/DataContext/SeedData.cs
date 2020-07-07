using MTS.PL.Infra.Interfaces.Standard;
using MTS.PL.Entities.Core;
using MTS.PL.Interfaces.Standard;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTS.PL.DatabaseAccess.DataContext
{
    internal sealed class SeedData : ISeedData
    {
        public async Task<IEnumerable<IBLUserAccount>> GetDefaultAccountsSeedDataAsync()
        {
            var accountHolder = new List<IBLUserAccount>();

            accountHolder.AddRange(await CreateAdminAccounts());
            accountHolder.AddRange(await CreatePrivilegedEmployeeAccounts());

            return accountHolder;
        }

        private Task<IEnumerable<IBLUserAccount>> CreateAdminAccounts()
        {
            var accountHolder = new IBLUserAccount[]
            {
                new DALUserAccount
                {
                    IsAdmitted = true,
                    EmailConfirmed = true,
                    FirstName = "Maurice",
                    LastName = "Slegtenhorst",
                    Email = "mauricetechsolution@outlook.com",
                    UserName = "mauricetechsolution@outlook.com",
                    PhoneNumber = "0645377536",
                },

                new DALUserAccount
                {
                    IsAdmitted = true,
                    EmailConfirmed = true,
                    FirstName = "Maurice2",
                    LastName = "Slegtenhorst",
                    Email = "bertus@bertus.nl",
                    UserName = "bertus@bertus.nl",
                    PhoneNumber = "0612345678",
                }
            };

            return Task.FromResult(accountHolder.AsEnumerable());
        }

        private Task<IEnumerable<IBLUserAccount>> CreatePrivilegedEmployeeAccounts()
        {
            var accountHolder = new IBLUserAccount[]
            {
                new DALUserAccount
                {
                    IsAdmitted = true,
                    EmailConfirmed = true,
                    FirstName = "Hanneke",
                    LastName = "Slegtenhorst",
                    Email = "hanneke.slegtenhorst1@gmail.com",
                    UserName = "hanneke.slegtenhorst1@gmail.com",
                    PhoneNumber = "0612345678",
                },

                new DALUserAccount
                {
                    IsAdmitted = true,
                    EmailConfirmed = true,
                    FirstName = "PrivilegedEmployee_02",
                    LastName = "None",
                    Email = "PrivilegedEmployee@MTS.nl",
                    UserName = "PrivilegedEmployee@MTS.nl",
                    PhoneNumber = "0612345678",
                }
            };

            return Task.FromResult(accountHolder.AsEnumerable());
        }
    }
}
