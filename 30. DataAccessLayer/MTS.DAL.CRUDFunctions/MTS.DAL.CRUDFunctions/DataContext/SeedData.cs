using MTS.DAL.Interfaces.Standard;
using System.Linq;
using System.Threading.Tasks;
using MTS.DAL.Entities.Core;
using Microsoft.EntityFrameworkCore;
using System;
using MTS.DAL.Entities.Core.EditPageContent;
using MTS.Core.GlobalLibrary;
using System.Text;
using Microsoft.AspNetCore.Identity;
using MTS.DAL.Entities.Core.Credit;

namespace MTS.DAL.DatabaseAccess.DataContext
{
    internal sealed class SeedData : ISeedData
    {
        public Task SeedPageSectionsAsync(object builderObject)
        {
            var builder = (ModelBuilder)builderObject;

            Guid[] sectionIds = new Guid[]
            {
                Guid.NewGuid(),
                Guid.NewGuid()
            };

            builder.Entity<DALPageSection>(pageSection =>
            {
                pageSection.HasData(
                    new DALPageSection
                    {
                        PageSectionId = sectionIds[0],
                        SectionNumber = 0,
                        PageRoute = "Index"
                    },
                    new DALPageSection
                    {
                        PageSectionId = sectionIds[1],
                        SectionNumber = 1,
                        PageRoute = "Index"
                    }
                );
            });

            builder.Entity<DALSectionPart>(sectionPart =>
            {
                sectionPart.HasData(
                #region Section 1
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
                    },
                #endregion
                #region Section 2
                    new DALSectionPart
                    {
                        SectionPartId = Guid.NewGuid(),
                        Type = "Title1",
                        Content = "<h4>Maurice Slegtenhorst</h4>",
                        PageSectionFK = sectionIds[1]
                    },
                    new DALSectionPart
                    {
                        SectionPartId = Guid.NewGuid(),
                        Type = "SubTitle1",
                        Content = "<h5>C# Software Developer</h5>",
                        PageSectionFK = sectionIds[1]
                    },
                    new DALSectionPart
                    {
                        SectionPartId = Guid.NewGuid(),
                        Type = "Header1",
                        Content = "<strong>Contact information</strong>",
                        PageSectionFK = sectionIds[1]
                    },
                    new DALSectionPart
                    {
                        SectionPartId = Guid.NewGuid(),
                        Type = "Body1",
                        Content =
                        "<div class=\"row\"><div class=\"col - 6\">Phone number:</div><div class=\"col - 6\">+31 645377536</div></div><div class=\"row\"><div class=\"col - 6\">Personal e-mail:</div><div class=\"col - 6\">maurice.slegtenhorst@outlook.com</div></div><div class=\"row\"><div class=\"col - 6\">Student e-mail</div><div class=\"col - 6\">maurice.slegtenhorst@itvitaelearning.nl</div></div></p>",
                        PageSectionFK = sectionIds[1]
                    },
                    new DALSectionPart
                    {
                        SectionPartId = Guid.NewGuid(),
                        Type = "Header2",
                        Content = "<strong>What can he do?</strong>",
                        PageSectionFK = sectionIds[1]
                    },
                    new DALSectionPart
                    {
                        SectionPartId = Guid.NewGuid(),
                        Type = "Body2",
                        Content = $"<p>{Constants.MSS.MAURICE_SKILLS}</p>",
                        PageSectionFK = sectionIds[1]
                    },
                    new DALSectionPart
                    {
                        SectionPartId = Guid.NewGuid(),
                        Type = "Header3",
                        Content = "<strong>Maurice in a nutshell</strong>",
                        PageSectionFK = sectionIds[1]
                    },
                    new DALSectionPart
                    {
                        SectionPartId = Guid.NewGuid(),
                        Type = "Body3",
                        Content = $"<p>{Constants.MSS.ABOUT_MAURICE_SHORT}</p>",
                        PageSectionFK = sectionIds[1]
                    }
                    #endregion
                );
            });

            return Task.CompletedTask;
        }

        public Task SeedAccountsAsync(object builderObject)
        {
            var builder = (ModelBuilder)builderObject;

            DALUserAccount[] accounts = CreateAccounts();
            builder.Entity<DALUserAccount>(userAccount => userAccount.HasData
            (
                accounts
            ));

            IdentityRole[] identityRoles = CreateIdentityRoles();
            builder.Entity<IdentityRole>(identityRole => identityRole.HasData
            (
                identityRoles
            ));

            IdentityUserRole<string>[] identityUserRoles = CreateIdentityUserRoles(accounts, identityRoles);
            builder.Entity<IdentityUserRole<string>>(userAccount => userAccount.HasData
            (
               identityUserRoles
            ));

            return Task.CompletedTask;
        }

        public Task SeedCredits(object builderObject)
        {
            var builder = (ModelBuilder)builderObject;

            DALCreditCategory[] creditCategories = CreateCreditCategories();
            builder.Entity<DALCreditCategory>(creditCategory => creditCategory.HasData
            (
               creditCategories
            ));

            DALCredit[] credits = CreateCredits(creditCategories);
            builder.Entity<DALCredit>(credit => credit.HasData
            (
               credits
            ));

            return Task.CompletedTask;
        }

        private DALCreditCategory[] CreateCreditCategories()
        {
            return new DALCreditCategory[]
            {
                new DALCreditCategory
                {
                    CreditCategoryId = Guid.NewGuid(),
                    Title = "<h4>Don't reinvent the wheel<h4>",
                    SubTitle = "<h5>Sources that made UI development easier</h5>"
                },
                new DALCreditCategory
                {
                    CreditCategoryId = Guid.NewGuid(),
                    Title = "<h4>Food for the brain<h4>",
                    SubTitle = "<h5>Sources that helped me gaining knoledge about programming related subjects</h5>"
                }
            };
        }

        private DALCredit[] CreateCredits(DALCreditCategory[] creditCategories)
        {
            return new DALCredit[]
            {
                new DALCredit
                {
                    CreditId = Guid.NewGuid(),
                    Title = "<h4>Open Iconic</h4>",
                    SubTitle = "<h5>Provider of fonts and icons</h5>",
                    LinkToImage = "https://img.stackshare.io/service/3029/iconic.png",
                    GotFrom ="Got from: <a href='https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor'>Blazor WebAssembly project builder</a>",
                    MadeBy = "Made by: <a href='https://useiconic.com/open'>Open-Iconic</a>",
                    Description = "<p>Most, if not all icons came from this provider. This font came with the project when it was created. I kept it for its ease of use.</p>",
                    CreditCategoryFK = creditCategories.First(creditCategory => creditCategory.Title == "<h4>Don't reinvent the wheel<h4>").CreditCategoryId
                },
                new DALCredit
                {
                    CreditId = Guid.NewGuid(),
                    Title = "<h4>Syncfusion</h4>",
                    SubTitle = "<h5>Easy to use premade Blazor components</h5>",
                    LinkToImage = "https://cdn.syncfusion.com/content/images/Logo/Logo_150dpi.png",
                    GotFrom = "Got from: <a href='https://www.syncfusion.com/products/communitylicense'>Syncfusion community license</a>",
                    MadeBy = "Made by: <a href='https://www.syncfusion.com/blazor-components'>Syncfusion website</a>",
                    Description = "<p>Some tasks while creating an UI are repetative. Syncfusion helps by providing components for repetative use.</p>",
                    CreditCategoryFK = creditCategories.First(creditCategory => creditCategory.Title == "<h4>Don't reinvent the wheel<h4>").CreditCategoryId
                },
                new DALCredit
                {
                    CreditId = Guid.NewGuid(),
                    Title = "<h4>Tim Corey</h4>",
                    SubTitle = "<h5>Youtuber with the best C# tuturials</h5>",
                    LinkToImage = "https://avatars3.githubusercontent.com/u/1839873?s=400&v=4",
                    GotFrom = "Got from: searching for tutorial video's on <a href='https://www.youtube.com'>YouTube</a> about C#",
                    MadeBy = "Made by: <a href='https://www.youtube.com/timcorey'>Tim Corey's YouTube channel</a>",
                    Description = "<p>Tim Corey provides many educational video's and tutorials about programming. His content is focused on C# but he covers other languages too. His goal is to make learning C# easier. Awesome guy.</p>",
                    CreditCategoryFK = creditCategories.First(creditCategory => creditCategory.Title == "<h4>Food for the brain<h4>").CreditCategoryId
                }
            };
        }

        private IdentityRole[] CreateIdentityRoles()
        {
            return new IdentityRole[]
            {
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = Constants.Security.ADMINISTRATOR,
                    NormalizedName = Constants.Security.ADMINISTRATOR.ToUpper()
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = Constants.Security.PRIVILEGED_EMPLOYEE,
                    NormalizedName = Constants.Security.PRIVILEGED_EMPLOYEE.ToUpper()
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = Constants.Security.EMPLOYEE,
                    NormalizedName = Constants.Security.EMPLOYEE.ToUpper()
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = Constants.Security.VOLENTEER,
                    NormalizedName = Constants.Security.VOLENTEER.ToUpper()
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = Constants.Security.PRIVILEGED_USER,
                    NormalizedName = Constants.Security.PRIVILEGED_USER.ToUpper()
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = Constants.Security.STANDARD_USER,
                    NormalizedName = Constants.Security.STANDARD_USER.ToUpper()
                }
            };
        }

        private IdentityUserRole<string>[] CreateIdentityUserRoles(DALUserAccount[] accounts, IdentityRole[] identityRoles)
        {
            return new IdentityUserRole<string>[]
            {
                new IdentityUserRole<string> 
                {
                    RoleId = identityRoles.First(role => role.Name == Constants.Security.ADMINISTRATOR).Id, 
                    UserId = accounts.First(account => account.Email == "mauricesoftwaresolution@outlook.com").Id 
                },
                new IdentityUserRole<string> 
                {
                    RoleId = identityRoles.First(role => role.Name == Constants.Security.ADMINISTRATOR).Id,
                    UserId = accounts.First(account => account.Email == "hanneke.slegtenhorst1@gmail.com").Id 
                },
                new IdentityUserRole<string> 
                {
                    RoleId = identityRoles.First(role => role.Name == Constants.Security.PRIVILEGED_EMPLOYEE).Id,
                    UserId = accounts.First(account => account.Email == "privilegedemployee01@mss.nl").Id 
                },
                new IdentityUserRole<string> 
                { 
                    RoleId = identityRoles.First(role => role.Name == Constants.Security.EMPLOYEE).Id,
                    UserId = accounts.First(account => account.Email == "employee01@mss.nl").Id 
                },
                new IdentityUserRole<string> 
                { 
                    RoleId = identityRoles.First(role => role.Name == Constants.Security.STANDARD_USER).Id,
                    UserId =  accounts.First(account => account.Email == "standarduser01@mts.nl").Id 
                }
            };
        }

        private DALUserAccount[] CreateAccounts()
        {
            //TODO Get this from Envirement Variables. Hardcoding password is not safe.
            string p = new PasswordHasher<DALUserAccount>().HashPassword(new DALUserAccount(), "MTS1991Password!");

            return new DALUserAccount[]
            {
                new DALUserAccount
                {
                    Id = Guid.NewGuid().ToString(),
                    IsAdmitted = true,
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    FirstName = "Maurice",
                    LastName = "Slegtenhorst",
                    Email = "mauricesoftwaresolution@outlook.com",
                    NormalizedEmail = "mauricesoftwaresolution@outlook.com".ToUpper(),
                    UserName = "mauricesoftwaresolution@outlook.com",
                    PasswordHash = p,
                    NormalizedUserName = "mauricesoftwaresolution@outlook.com".ToUpper(),
                    PhoneNumber = "0645377536"
                },
                new DALUserAccount
                {
                    Id = Guid.NewGuid().ToString(),
                    IsAdmitted = true,
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    FirstName = "Hanneke",
                    LastName = "Slegtenhorst",
                    Email = "hanneke.slegtenhorst1@gmail.com",
                    NormalizedEmail = "hanneke.slegtenhorst1@gmail.com".ToUpper(),
                    UserName = "hanneke.slegtenhorst1@gmail.com",
                    PasswordHash = p,
                    NormalizedUserName = "hanneke.slegtenhorst1@gmail.com".ToUpper(),
                    PhoneNumber = "06" + new Random().Next(0, 99999999).ToString("D10")
                },
                new DALUserAccount
                {
                    Id = Guid.NewGuid().ToString(),
                    IsAdmitted = true,
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    FirstName = "PrivilegedEmployee_01",
                    LastName = "None",
                    Email = "privilegedemployee01@mss.nl",
                    NormalizedEmail = "privilegedemployee01@mss.nl".ToUpper(),
                    UserName = "privilegedemployee01@mss.nl",
                    PasswordHash = p,
                    NormalizedUserName = "PrivilegedEmployee01@mss.nl".ToUpper(),
                    PhoneNumber = "06" + new Random().Next(0, 99999999).ToString("D10")
                },
                new DALUserAccount
                {
                    Id = Guid.NewGuid().ToString(),
                    IsAdmitted = true,
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    FirstName = "Employee_01",
                    LastName = "None",
                    Email = "employee01@mss.nl",
                    NormalizedEmail = "employee01@mss.nl".ToUpper(),
                    UserName = "Employee01@MTS.nl",
                    PasswordHash = p,
                    NormalizedUserName = "Employee01@MTS.nl".ToUpper(),
                    PhoneNumber = "06" + new Random().Next(0, 99999999).ToString("D10")
                },
                new DALUserAccount
                {
                    Id = Guid.NewGuid().ToString(),
                    IsAdmitted = true,
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    FirstName = "StandardUser_01",
                    LastName = "None",
                    Email = "standarduser01@mts.nl",
                    NormalizedEmail = "standarduser01@mss.nl".ToUpper(),
                    UserName = "standarduser01@mts.nl",
                    PasswordHash = p,
                    NormalizedUserName = "standarduser01@mss.nl".ToUpper(),
                    PhoneNumber = "06" + new Random().Next(0, 99999999).ToString("D10")
                }
            };
        }
    }
}
