using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MTS.BL.Infra.Interfaces.Standard.EditPageContent;
using MTS.Core.GlobalLibrary;
using MTS.DAL.Entities.Core;
using MTS.DAL.Entities.Core.EditPageContent;
using MTS.DAL.Interfaces.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTS.DAL.DatabaseAccess.DataContext
{
    public sealed class ApplicationDbContext : IdentityDbContext<DALUserAccount>
    {
        private readonly ISeedData _seedData;

        public DbSet<DALPageSection> PageSections { get; set; }
        public DbSet<DALSectionPart> SectionParts { get; set; }
        public DbSet<DALUserAccount> UserAccounts { get; set; }
        public DbSet<DALCredit> Credits { get; set; }

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            ISeedData seedData)
            : base(options)
        {
            _seedData = seedData;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            Guid[] sectionIds = new Guid[]
            {
                Guid.NewGuid()
            };

            builder.Entity<DALPageSection>(pageSection => 
            {
                pageSection.HasData(new DALPageSection
                {
                    PageSectionId = sectionIds[0],
                    PageRoute = "Index"
                });
            });

            builder.Entity<DALSectionPart>(sectionPart =>
            {
                sectionPart.HasData(
                    new DALSectionPart
                    {
                        SectionPartId = Guid.NewGuid(),
                        Type = "Title1",
                        Content = "About me and MSS",
                        PageSectionFK = sectionIds[0]
                    },
                    new DALSectionPart
                    {
                        SectionPartId = Guid.NewGuid(),
                        Type = "Header1",
                        Content = "What is MSS?",
                        PageSectionFK = sectionIds[0]
                    },
                    new DALSectionPart
                    {
                        SectionPartId = Guid.NewGuid(),
                        Type = "Body1",
                        Content = Constants.MSS.WHAT_IS_MSS,
                        PageSectionFK = sectionIds[0]
                    },
                    new DALSectionPart
                    {
                        SectionPartId = Guid.NewGuid(),
                        Type = "Header2",
                        Content = "Who is Maurice?",
                        PageSectionFK = sectionIds[0]
                    },
                    new DALSectionPart
                    {
                        SectionPartId = Guid.NewGuid(),
                        Type = "Body2",
                        Content = new StringBuilder()
                        .AppendLine(Constants.MSS.ABOUT_MAURICE_1)
                        .AppendLine()
                        .AppendLine(Constants.MSS.ABOUT_MAURICE_2)
                        .AppendLine()
                        .AppendLine(Constants.MSS.ABOUT_MAURICE_3)
                        .AppendLine()
                        .AppendLine(Constants.MSS.ABOUT_MAURICE_4)
                        .AppendLine()
                        .AppendLine(Constants.MSS.ABOUT_MAURICE_5)
                        .AppendLine()
                        .AppendLine(Constants.MSS.ABOUT_MAURICE_6)
                        .AppendLine()
                        .AppendLine(Constants.MSS.ABOUT_MAURICE_7)
                        .ToString(),
                        PageSectionFK = sectionIds[0]
                    }
                    );
            });
            
        }
    }
}
