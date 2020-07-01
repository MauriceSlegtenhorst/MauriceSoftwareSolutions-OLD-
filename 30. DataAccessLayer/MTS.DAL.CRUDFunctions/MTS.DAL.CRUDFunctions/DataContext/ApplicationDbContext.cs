using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MTS.BL.Infra.Entities;
using MTS.BL.Infra.Interfaces;

namespace MTS.BL.DatabaseAccess.DataContext
{
    internal sealed class ApplicationDbContext : IdentityDbContext<EFUserAccount>
    {

        public DbSet<EFUserAccount> UserAccounts { get; set; }
        public DbSet<Credit> Credits { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
