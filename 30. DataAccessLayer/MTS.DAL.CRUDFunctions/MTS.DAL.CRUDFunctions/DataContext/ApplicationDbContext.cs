using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MTS.PL.Entities.Core;
using MTS.PL.Entities;
using MTS.DAL.Entities.Core.EditPageContent;

namespace MTS.PL.DatabaseAccess.DataContext
{
    public sealed class ApplicationDbContext : IdentityDbContext<DALUserAccount>
    {
        public DbSet<DALPageSection> PageSections { get; set; }
        public DbSet<DALUserAccount> UserAccounts { get; set; }
        public DbSet<Credit> Credits { get; set; }

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
