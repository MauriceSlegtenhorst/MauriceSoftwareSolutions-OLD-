using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MTS.DAL.Infra.Entities;
using MTS.DAL.Infra.Interfaces;
using System;
using System.Threading.Tasks;

namespace MTS.DAL.DatabaseAccess.DataContext
{
    public sealed class ApplicationDbContext : IdentityDbContext<EFUserAccount>
    {
        public DbSet<EFUserAccount> UserAccounts { get; set; }
        public DbSet<Credit> Credits { get; set; }

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
