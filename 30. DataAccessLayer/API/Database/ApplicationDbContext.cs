using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MTS.BL.Infra.APILibrary;
using MTS.DataAcces.AccountAPI.Entities;

namespace MTS.DAL.API.Database
{
    public class ApplicationDbContext : IdentityDbContext<EFUserAccount>
    {
        public DbSet<EFUserAccount> UserAccounts { get; set; }
        public DbSet<Credit> Credits { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
