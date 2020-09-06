using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MTS.BL.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    Affix = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    IsAdmitted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditCategories",
                columns: table => new
                {
                    CreditCategoryId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    SubTitle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCategories", x => x.CreditCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "PageSections",
                columns: table => new
                {
                    PageSectionId = table.Column<Guid>(nullable: false),
                    SectionNumber = table.Column<int>(nullable: false),
                    PageRoute = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageSections", x => x.PageSectionId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Credits",
                columns: table => new
                {
                    CreditId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    SubTitle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MadeBy = table.Column<string>(nullable: true),
                    MadeByWebsite = table.Column<string>(nullable: true),
                    GotFrom = table.Column<string>(nullable: true),
                    GotFromWebsite = table.Column<string>(nullable: true),
                    LinkToImage = table.Column<string>(nullable: true),
                    CreditCategoryFK = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credits", x => x.CreditId);
                    table.ForeignKey(
                        name: "FK_Credits_CreditCategories_CreditCategoryFK",
                        column: x => x.CreditCategoryFK,
                        principalTable: "CreditCategories",
                        principalColumn: "CreditCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectionParts",
                columns: table => new
                {
                    SectionPartId = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    PageSectionFK = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionParts", x => x.SectionPartId);
                    table.ForeignKey(
                        name: "FK_SectionParts_PageSections_PageSectionFK",
                        column: x => x.PageSectionFK,
                        principalTable: "PageSections",
                        principalColumn: "PageSectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ead5b150-ca04-4bce-a55d-83cf739dc7d8", "a009749f-22c8-41ce-8b71-7f3cf606ed9a", "administrator", "ADMINISTRATOR" },
                    { "4c70af36-f0fc-457c-aede-1b0ec2247518", "3c7a3847-2824-46dc-af28-8a59c42b3852", "privilegedemployee", "PRIVILEGEDEMPLOYEE" },
                    { "99e1d4e1-94b2-4ad0-9b63-56779bab8277", "8126c200-fb00-4a7a-ad68-39aac054b476", "employee", "EMPLOYEE" },
                    { "2aa69a56-324d-4b2e-858f-e12421a9657f", "dd841d33-b52f-4baf-a774-0afbe389cdd5", "volenteer", "VOLENTEER" },
                    { "126bccb1-67de-4865-8359-25f1eaf2c408", "d6287b54-a7f5-4d1d-95d8-2d97fb37bc16", "privilegeduser", "PRIVILEGEDUSER" },
                    { "fdf58f7d-b2ba-443a-84c1-f4ece9b839b5", "1fec1417-b9a2-4347-8c75-49c7eb9e78ca", "standarduser", "STANDARDUSER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Affix", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsAdmitted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3ac0d468-eaf7-45dc-a817-ae5224276540", 0, null, "ea34b86d-7e85-45fe-b7bb-0436154a2135", "mauricesoftwaresolution@outlook.com", true, "Maurice", true, "Slegtenhorst", true, null, "MAURICESOFTWARESOLUTION@OUTLOOK.COM", "MAURICESOFTWARESOLUTION@OUTLOOK.COM", "AQAAAAEAACcQAAAAEIcVZGJyAFQ/+su7fIl8qk+S2g21JC2T/5LMyjWbUfkg2/r4uu/De/6y8xQh6bSbzg==", "0645377536", true, "46db7ffc-2111-4100-b2e4-77efa6d12d2d", false, "mauricesoftwaresolution@outlook.com" },
                    { "7695a43b-9e4f-43a4-a6b7-bdf5fd1b9ebb", 0, null, "17d340a9-6d71-46f3-894f-8b73b85912b2", "hanneke.slegtenhorst1@gmail.com", true, "Hanneke", true, "Slegtenhorst", true, null, "HANNEKE.SLEGTENHORST1@GMAIL.COM", "HANNEKE.SLEGTENHORST1@GMAIL.COM", "AQAAAAEAACcQAAAAEIcVZGJyAFQ/+su7fIl8qk+S2g21JC2T/5LMyjWbUfkg2/r4uu/De/6y8xQh6bSbzg==", "060076761477", true, "f084ac69-a2f8-4889-a56c-d99c4202415f", false, "hanneke.slegtenhorst1@gmail.com" },
                    { "3cd4f0f2-67f6-43cf-8dbd-e47bf7ca5964", 0, null, "c0a5b443-dbc4-4c1d-94f3-70a752d4be76", "privilegedemployee01@mss.nl", true, "PrivilegedEmployee_01", true, "None", true, null, "PRIVILEGEDEMPLOYEE01@MSS.NL", "PRIVILEGEDEMPLOYEE01@MSS.NL", "AQAAAAEAACcQAAAAEIcVZGJyAFQ/+su7fIl8qk+S2g21JC2T/5LMyjWbUfkg2/r4uu/De/6y8xQh6bSbzg==", "060090464683", true, "246ff64b-e568-4164-9a8e-7f987b762e8f", false, "privilegedemployee01@mss.nl" },
                    { "a797f750-7595-4b14-8490-964282d9792f", 0, null, "a7cb966d-eab3-45af-8ab4-31e3341de65a", "employee01@mss.nl", true, "Employee_01", true, "None", true, null, "EMPLOYEE01@MSS.NL", "EMPLOYEE01@MTS.NL", "AQAAAAEAACcQAAAAEIcVZGJyAFQ/+su7fIl8qk+S2g21JC2T/5LMyjWbUfkg2/r4uu/De/6y8xQh6bSbzg==", "060026821470", true, "d9c8ddc6-0e85-40e0-aa6e-c0bf3ba37f68", false, "Employee01@MTS.nl" },
                    { "c5a70434-3e5f-4dd9-86e4-e80c501c1935", 0, null, "c92bd219-6716-454e-bbe0-f40758dba802", "standarduser01@mts.nl", true, "StandardUser_01", true, "None", true, null, "STANDARDUSER01@MSS.NL", "STANDARDUSER01@MSS.NL", "AQAAAAEAACcQAAAAEIcVZGJyAFQ/+su7fIl8qk+S2g21JC2T/5LMyjWbUfkg2/r4uu/De/6y8xQh6bSbzg==", "060019710307", true, "ec5bd8b8-b99d-411f-acda-dfe8a2400bd4", false, "standarduser01@mts.nl" }
                });

            migrationBuilder.InsertData(
                table: "CreditCategories",
                columns: new[] { "CreditCategoryId", "Description", "SubTitle", "Title" },
                values: new object[] { new Guid("02e668f8-f7ca-4f8a-b033-09f61878f803"), null, "<h5>Sources that made UI development easier</h5>", "<h4>Don't reinvent the wheel<h4>" });

            migrationBuilder.InsertData(
                table: "PageSections",
                columns: new[] { "PageSectionId", "PageRoute", "SectionNumber" },
                values: new object[,]
                {
                    { new Guid("c6e63cbd-588e-4283-a410-3a489c979525"), "Index", 0 },
                    { new Guid("b8505101-d148-4869-ba87-0023a8cf634e"), "Index", 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "c5a70434-3e5f-4dd9-86e4-e80c501c1935", "fdf58f7d-b2ba-443a-84c1-f4ece9b839b5" },
                    { "3cd4f0f2-67f6-43cf-8dbd-e47bf7ca5964", "4c70af36-f0fc-457c-aede-1b0ec2247518" },
                    { "7695a43b-9e4f-43a4-a6b7-bdf5fd1b9ebb", "ead5b150-ca04-4bce-a55d-83cf739dc7d8" },
                    { "3ac0d468-eaf7-45dc-a817-ae5224276540", "ead5b150-ca04-4bce-a55d-83cf739dc7d8" },
                    { "a797f750-7595-4b14-8490-964282d9792f", "99e1d4e1-94b2-4ad0-9b63-56779bab8277" }
                });

            migrationBuilder.InsertData(
                table: "Credits",
                columns: new[] { "CreditId", "CreditCategoryFK", "Description", "GotFrom", "GotFromWebsite", "LinkToImage", "MadeBy", "MadeByWebsite", "SubTitle", "Title" },
                values: new object[,]
                {
                    { new Guid("f386ce3e-8087-4cb8-bf2a-b541f0edd169"), new Guid("02e668f8-f7ca-4f8a-b033-09f61878f803"), "<p>Most, if not all icons came from this provider. This font came with the project when it was created. I kept it for its ease of use.</p>", "Blazor WebAssembly project builder", "https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor", "https://img.stackshare.io/service/3029/iconic.png", null, "https://useiconic.com/open", "<h5>Provider of fonts and icons</h5>", "<h4>Open Iconic</h4>" },
                    { new Guid("78d0bc31-c3d1-4e6e-b8e0-3c9d9ce2c340"), new Guid("02e668f8-f7ca-4f8a-b033-09f61878f803"), "<p>Some tasks while creating an UI are repetative. Syncfusion helps by providing components that cover these needs.</p>", "Syncfusion community license", "https://www.syncfusion.com/products/communitylicense", "https://cdn.syncfusion.com/content/images/Logo/Logo_150dpi.png", null, "https://www.syncfusion.com/blazor-components", "<h5>Easy to use premade Blazor components</h5>", "<h4>Syncfusion</h4>" }
                });

            migrationBuilder.InsertData(
                table: "SectionParts",
                columns: new[] { "SectionPartId", "Content", "PageSectionFK", "Type" },
                values: new object[,]
                {
                    { new Guid("eb61a4f0-2817-444e-90f8-79d16b2f4529"), @"<p>I am an enthusiastic man with a strong passion for programming. Social and friendly going. Coding has been my hobby from an early age. When I was 13, I made my first program in Visual Basic. A slot machine where there were secret options to get infinite money for example. Later, around the age of 18, I started working with Java, XML and Android Studio. With this I built a number of Android apps including an applocker. This app allowed the user to choose which apps and services needed an additional password or fingerprint to be used.</p>
                <p>Friends and especially family regularly ask me for help with electronics and software related matters. I think this is because I have been busy with software and hardware practically my whole life.</p>
                <p>Marketing and commerce seemed to be my career choice for a long time. During my higher professional education, Commercial Economics, I found out that this did not meet my expectations.</p>
                <p>At one point I ended up at ITvitae and started working on my C# programming skills. This went well for me because Java is similar in syntax to C#. Here I have made several complicated programs with C# and related languages such as SQL, HTML XAML, JavaScript and CSS. At ITvitae I have greatly improved my software development skills. After about a year I have successfully completed the process.</p>
                <p>My interests lie in the latest techniques in software development and electronics. In particular what advantages and disadvantages there are. For example, I can get enthusiastic about developments such as Blazor. This offers such cool options within the internet landscape. For example, the website can be installed as a local application and C# can be used instead of JavaScript! If I find something interesting, I want to find out and test it. See what has gotten better or worse.</p>
                <p>Besides my passion for programming, I am also interested in hardware. For example, I have built my own PC and home server. That very server you are accessing right now.</p>
                <p>That’s it. If you want to know more about me or Maurice Software Solutions, please navigate to the feedback or contact page to ask your question</p>", new Guid("c6e63cbd-588e-4283-a410-3a489c979525"), "Body2" },
                    { new Guid("d672d408-624b-425b-84c0-c09779aaad42"), "<h4>Maurice Slegtenhorst</h4>", new Guid("b8505101-d148-4869-ba87-0023a8cf634e"), "Title1" },
                    { new Guid("71067f26-7cf1-4aba-a9d5-c101b0725633"), "<h5>C# Software Developer</h5>", new Guid("b8505101-d148-4869-ba87-0023a8cf634e"), "SubTitle1" },
                    { new Guid("852bf666-646e-4c1a-bd24-e80b78da167d"), "<p>Maurice Software Solutions was created to showcase my programming skills and to have some fun. Aside from that there is handy and fun functionality to be found like a fully-fledged, unlimited personal cloud storage system and a chatroom. And those are just the things I am currently working on. I am dedicated to improving Maurice Software Solutions as a whole regularly whilst adding cool new features.</p>", new Guid("c6e63cbd-588e-4283-a410-3a489c979525"), "Body1" },
                    { new Guid("6c8e8c7f-4955-4d02-a8d7-d8f4900277a4"), "<div class=\"row\"><div class=\"col - 6\">Phone number:</div><div class=\"col - 6\">+31 645377536</div></div><div class=\"row\"><div class=\"col - 6\">Personal e-mail:</div><div class=\"col - 6\">maurice.slegtenhorst@outlook.com</div></div><div class=\"row\"><div class=\"col - 6\">Student e-mail</div><div class=\"col - 6\">maurice.slegtenhorst@itvitaelearning.nl</div></div></p>", new Guid("b8505101-d148-4869-ba87-0023a8cf634e"), "Body1" },
                    { new Guid("179f4afb-7f98-416e-aea8-4d7eeb65e0d5"), "<strong>What can he do?</strong>", new Guid("b8505101-d148-4869-ba87-0023a8cf634e"), "Header2" },
                    { new Guid("1a9ece75-da90-41db-8d6b-0f041e962b23"), "<p>C#, JavaScript, SQL, HTML5, CSS3, XAML and XML</p>", new Guid("b8505101-d148-4869-ba87-0023a8cf634e"), "Body2" },
                    { new Guid("f8c48f69-4c87-4d50-8475-fca56da175da"), "<strong>Maurice in a nutshell</strong>", new Guid("b8505101-d148-4869-ba87-0023a8cf634e"), "Header3" },
                    { new Guid("c2caf1ac-6e69-4a25-b1ce-dc6e5d1f98f4"), "<p>Born on 27th of april 1991 and living in The Netherlands sinds then. Loves coding and fiddling with electronics. Likes to go for a jog or socialize</p>", new Guid("b8505101-d148-4869-ba87-0023a8cf634e"), "Body3" },
                    { new Guid("0648cb01-e522-41fa-be4e-f3c7664e1ac4"), "<strong>What is MSS?</strong>", new Guid("c6e63cbd-588e-4283-a410-3a489c979525"), "Header1" },
                    { new Guid("1964c609-c7b6-4b1f-ab06-653c1fa71a2b"), "<h4>About me and MSS</h4>", new Guid("c6e63cbd-588e-4283-a410-3a489c979525"), "Title1" },
                    { new Guid("dd640107-8672-4103-83dd-bf67259ee3c4"), "<strong>Who is Maurice?</strong>", new Guid("c6e63cbd-588e-4283-a410-3a489c979525"), "Header2" },
                    { new Guid("110248e6-4a87-4a86-88a9-6b38e7577414"), "<strong>Contact information</strong>", new Guid("b8505101-d148-4869-ba87-0023a8cf634e"), "Header1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Credits_CreditCategoryFK",
                table: "Credits",
                column: "CreditCategoryFK");

            migrationBuilder.CreateIndex(
                name: "IX_SectionParts_PageSectionFK",
                table: "SectionParts",
                column: "PageSectionFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Credits");

            migrationBuilder.DropTable(
                name: "SectionParts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CreditCategories");

            migrationBuilder.DropTable(
                name: "PageSections");
        }
    }
}
