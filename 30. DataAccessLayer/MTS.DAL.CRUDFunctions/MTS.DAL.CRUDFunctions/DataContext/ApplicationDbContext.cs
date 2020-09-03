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
                        Content = "<h4>About me and MSS</h4>",
                        PageSectionFK = sectionIds[0]
                    },
                    new DALSectionPart
                    {
                        SectionPartId = Guid.NewGuid(),
                        Type = "Header1",
                        Content = "<strong>What is MSS?</strong>",
                        PageSectionFK = sectionIds[0]
                    },
                    new DALSectionPart
                    {
                        SectionPartId = Guid.NewGuid(),
                        Type = "Body1",
                        Content = $"<p>{Constants.MSS.WHAT_IS_MSS}</p>",
                        PageSectionFK = sectionIds[0]
                    },
                    new DALSectionPart
                    {
                        SectionPartId = Guid.NewGuid(),
                        Type = "Header2",
                        Content = "<strong>Who is Maurice?</strong>",
                        PageSectionFK = sectionIds[0]
                    },
                    new DALSectionPart
                    {
                        SectionPartId = Guid.NewGuid(),
                        Type = "Body2",
                        Content = new StringBuilder()
                        .Append("<p>").Append(Constants.MSS.ABOUT_MAURICE_1).Append("</p>")
                        .AppendLine()
                        .Append("<p>").Append(Constants.MSS.ABOUT_MAURICE_2).Append("</p>")
                        .AppendLine()
                        .Append("<p>").Append(Constants.MSS.ABOUT_MAURICE_3).Append("</p>")
                        .AppendLine()
                        .Append("<p>").Append(Constants.MSS.ABOUT_MAURICE_4).Append("</p>")
                        .AppendLine()
                        .Append("<p>").Append(Constants.MSS.ABOUT_MAURICE_5).Append("</p>")
                        .AppendLine()
                        .Append("<p>").Append(Constants.MSS.ABOUT_MAURICE_6).Append("</p>")
                        .AppendLine()
                        .Append("<p>").Append(Constants.MSS.ABOUT_MAURICE_7).Append("</p>")
                        .ToString(),
                        PageSectionFK = sectionIds[0]
                    }
                    );
            });
            
        }
    }
}
