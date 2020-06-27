using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MTS.DAL.Infra.Interfaces;

namespace MTS.DAL.DatabaseAccess.DataContext
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
