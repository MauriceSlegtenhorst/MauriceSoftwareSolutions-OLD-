using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MTS.DAL.Infra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MTS.DAL.DatabaseAccess.DataContext
{
    internal sealed class SeedData : ISeedData
    {
        public async Task<IEnumerable<EFUserAccount>> GetDefaultAccountsSeedDataAsync()
        {
            var accountHolder = new List<EFUserAccount>();

            accountHolder.AddRange(await CreateAdminAccounts());
            accountHolder.AddRange(await CreatePrivilegedEmployeeAccounts());

            return accountHolder;
        }

        private Task<IEnumerable<EFUserAccount>> CreateAdminAccounts()
        {
            var accountHolder = new EFUserAccount[]
            {
                new EFUserAccount
                {
                    IsAdmitted = true,
                    EmailConfirmed = true,
                    FirstName = "Maurice",
                    LastName = "Slegtenhorst",
                    Email = "mauricetechsolution@outlook.com",
                    UserName = "mauricetechsolution@outlook.com",
                    PhoneNumber = "0645377536",
                },

                new EFUserAccount
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

        private Task<IEnumerable<EFUserAccount>> CreatePrivilegedEmployeeAccounts()
        {
            var accountHolder = new EFUserAccount[]
            {
                new EFUserAccount
                {
                    IsAdmitted = true,
                    EmailConfirmed = true,
                    FirstName = "Hanneke",
                    LastName = "Slegtenhorst",
                    Email = "hanneke.slegtenhorst1@gmail.com",
                    UserName = "hanneke.slegtenhorst1@gmail.com",
                    PhoneNumber = "0612345678",
                },

                new EFUserAccount
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
