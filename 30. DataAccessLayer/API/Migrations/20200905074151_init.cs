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
                name: "Credits",
                columns: table => new
                {
                    CreditId = table.Column<Guid>(nullable: false),
                    MadeBy = table.Column<string>(nullable: true),
                    GotFrom = table.Column<string>(nullable: true),
                    LinkToImage = table.Column<string>(nullable: true),
                    AuthorWebsite = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credits", x => x.CreditId);
                });

            migrationBuilder.CreateTable(
                name: "PageSections",
                columns: table => new
                {
                    PageSectionId = table.Column<Guid>(nullable: false),
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
                    { "d4be0aa2-d394-4324-9301-6b0e83d6871d", "befe7b7e-0771-4388-bd51-f00687800f3e", "administrator", "ADMINISTRATOR" },
                    { "d8ef71df-4a62-4790-83ce-c15675027a9d", "c35275cd-162a-4be8-932e-d17f107953d2", "privilegedemployee", "PRIVILEGEDEMPLOYEE" },
                    { "b9a4c02a-ef45-414c-9681-78d7bcfd4ab0", "5eb8ee71-28ca-44b0-8120-daf201c4918e", "employee", "EMPLOYEE" },
                    { "f36c72e5-4d61-437e-a735-e8c749742de8", "d2195338-bda2-46e6-83e1-0908468fdbb5", "volenteer", "VOLENTEER" },
                    { "079fecff-1904-4b72-942f-987aa2f8ccb6", "9e4f4a24-7a28-4c1a-b4ab-cc7efd0f7022", "privilegeduser", "PRIVILEGEDUSER" },
                    { "b347297d-d6bf-4082-8dcf-d156510b9c8a", "2c0eed2b-c76f-40ac-998e-6ff5e83ace6f", "standarduser", "STANDARDUSER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Affix", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsAdmitted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6a543003-ac31-4db5-8900-66ed4178d576", 0, null, "31733f2c-f4c0-4b7d-a816-c7dd0d9e9c60", "mauricesoftwaresolution@outlook.com", true, "Maurice", true, "Slegtenhorst", true, null, "MAURICESOFTWARESOLUTION@OUTLOOK.COM", "MAURICESOFTWARESOLUTION@OUTLOOK.COM", "AQAAAAEAACcQAAAAEHait8D6dTkmW3iXth8zPNDHAGkYHjA771sTtCrXDPkW+dB2URe0NbytgE6D5cwQKA==", "0645377536", true, "fbc91da7-ab15-4855-91b8-e63fa51c97ba", false, "mauricesoftwaresolution@outlook.com" },
                    { "dfdf6cd0-19e9-4fb9-bb1d-76e214a0348a", 0, null, "d488f99f-5f39-4f40-9ba0-d4aaf5268935", "hanneke.slegtenhorst1@gmail.com", true, "Hanneke", true, "Slegtenhorst", true, null, "HANNEKE.SLEGTENHORST1@GMAIL.COM", "HANNEKE.SLEGTENHORST1@GMAIL.COM", "AQAAAAEAACcQAAAAEHait8D6dTkmW3iXth8zPNDHAGkYHjA771sTtCrXDPkW+dB2URe0NbytgE6D5cwQKA==", "060017836617", true, "28afc327-3f9e-4c5f-ac5f-d7161625a7b1", false, "hanneke.slegtenhorst1@gmail.com" },
                    { "6ee3220d-7dc0-4da5-ac1d-2c23c14c0c5b", 0, null, "6b36d726-3939-4fda-8d2d-2e1fac74b901", "privilegedemployee01@mss.nl", true, "PrivilegedEmployee_01", true, "None", true, null, "PRIVILEGEDEMPLOYEE01@MSS.NL", "PRIVILEGEDEMPLOYEE01@MSS.NL", "AQAAAAEAACcQAAAAEHait8D6dTkmW3iXth8zPNDHAGkYHjA771sTtCrXDPkW+dB2URe0NbytgE6D5cwQKA==", "060042849790", true, "c86cdcc5-b903-45aa-8895-82e1234e661e", false, "privilegedemployee01@mss.nl" },
                    { "51947d08-905f-46b0-90f7-4ab8078e782e", 0, null, "a022f27c-f719-408a-894f-d9a2a519509d", "employee01@mss.nl", true, "Employee_01", true, "None", true, null, "EMPLOYEE01@MSS.NL", "EMPLOYEE01@MTS.NL", "AQAAAAEAACcQAAAAEHait8D6dTkmW3iXth8zPNDHAGkYHjA771sTtCrXDPkW+dB2URe0NbytgE6D5cwQKA==", "060038506665", true, "3eb8f005-b421-4a58-a066-cc11e8578532", false, "Employee01@MTS.nl" },
                    { "e2f80e16-9aec-4e07-a5c6-58f021d17afa", 0, null, "595ff8b9-b824-463c-8cfe-af505b0f211b", "standarduser01@mts.nl", true, "StandardUser_01", true, "None", true, null, "STANDARDUSER01@MSS.NL", "STANDARDUSER01@MSS.NL", "AQAAAAEAACcQAAAAEHait8D6dTkmW3iXth8zPNDHAGkYHjA771sTtCrXDPkW+dB2URe0NbytgE6D5cwQKA==", "060073334147", true, "125a43e9-b24b-45a0-85de-cd3c0452d322", false, "standarduser01@mts.nl" }
                });

            migrationBuilder.InsertData(
                table: "PageSections",
                columns: new[] { "PageSectionId", "PageRoute" },
                values: new object[,]
                {
                    { new Guid("952dbfe4-42f0-46ac-87cd-8fc1f8acf862"), "Index" },
                    { new Guid("e080f91f-8487-4515-93a0-e5b50060ed3c"), "Index" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "e2f80e16-9aec-4e07-a5c6-58f021d17afa", "b347297d-d6bf-4082-8dcf-d156510b9c8a" },
                    { "6ee3220d-7dc0-4da5-ac1d-2c23c14c0c5b", "d8ef71df-4a62-4790-83ce-c15675027a9d" },
                    { "dfdf6cd0-19e9-4fb9-bb1d-76e214a0348a", "d4be0aa2-d394-4324-9301-6b0e83d6871d" },
                    { "6a543003-ac31-4db5-8900-66ed4178d576", "d4be0aa2-d394-4324-9301-6b0e83d6871d" },
                    { "51947d08-905f-46b0-90f7-4ab8078e782e", "b9a4c02a-ef45-414c-9681-78d7bcfd4ab0" }
                });

            migrationBuilder.InsertData(
                table: "SectionParts",
                columns: new[] { "SectionPartId", "Content", "PageSectionFK", "Type" },
                values: new object[,]
                {
                    { new Guid("ab503d45-82a1-4b5b-91fd-4daa9043da32"), "<p>Born on 27th of april 1991 and living in The Netherlands sinds then. Loves coding and fiddling with electronics. Likes to go for a jog or socialize</p>", new Guid("e080f91f-8487-4515-93a0-e5b50060ed3c"), "Body3" },
                    { new Guid("7847fc82-0913-4ab7-8fea-dc2c4ee59301"), "<strong>Maurice in a nutshell</strong>", new Guid("e080f91f-8487-4515-93a0-e5b50060ed3c"), "Header3" },
                    { new Guid("3843a84c-4028-4f1a-9c43-4d6a518502a5"), "<p>C#, JavaScript, SQL, HTML5, CSS3, XAML and XML</p>", new Guid("e080f91f-8487-4515-93a0-e5b50060ed3c"), "Body2" },
                    { new Guid("aa303979-bc14-442e-8e05-8eaab8bdc177"), "<strong>What can he do?</strong>", new Guid("e080f91f-8487-4515-93a0-e5b50060ed3c"), "Header2" },
                    { new Guid("81317e89-bace-4a41-a152-ba2b6f9f7bc3"), "<div class=\"row\"><div class=\"col - 6\">Phone number:</div><div class=\"col - 6\">+31 645377536</div></div><div class=\"row\"><div class=\"col - 6\">Personal e-mail:</div><div class=\"col - 6\">maurice.slegtenhorst@outlook.com</div></div><div class=\"row\"><div class=\"col - 6\">Student e-mail</div><div class=\"col - 6\">maurice.slegtenhorst@itvitaelearning.nl</div></div></p>", new Guid("e080f91f-8487-4515-93a0-e5b50060ed3c"), "Body1" },
                    { new Guid("e84b936c-1555-4eae-9ee8-a6d43f54b26e"), "<h5>C# Software Developer</h5>", new Guid("e080f91f-8487-4515-93a0-e5b50060ed3c"), "SubTitle1" },
                    { new Guid("04c314d7-3853-482b-864f-15e230e7920d"), "<h4>Maurice Slegtenhorst</h4>", new Guid("e080f91f-8487-4515-93a0-e5b50060ed3c"), "Title1" },
                    { new Guid("b6193c4a-3bb6-42f5-9572-2178951fd91f"), @"<p>I am an enthusiastic man with a strong passion for programming. Social and friendly going. Coding has been my hobby from an early age. When I was 13, I made my first program in Visual Basic. A slot machine where there were secret options to get infinite money for example. Later, around the age of 18, I started working with Java, XML and Android Studio. With this I built a number of Android apps including an applocker. This app allowed the user to choose which apps and services needed an additional password or fingerprint to be used.</p>
                <p>Friends and especially family regularly ask me for help with electronics and software related matters. I think this is because I have been busy with software and hardware practically my whole life.</p>
                <p>Marketing and commerce seemed to be my career choice for a long time. During my higher professional education, Commercial Economics, I found out that this did not meet my expectations.</p>
                <p>At one point I ended up at ITvitae and started working on my C# programming skills. This went well for me because Java is similar in syntax to C#. Here I have made several complicated programs with C# and related languages such as SQL, HTML XAML, JavaScript and CSS. At ITvitae I have greatly improved my software development skills. After about a year I have successfully completed the process.</p>
                <p>My interests lie in the latest techniques in software development and electronics. In particular what advantages and disadvantages there are. For example, I can get enthusiastic about developments such as Blazor. This offers such cool options within the internet landscape. For example, the website can be installed as a local application and C# can be used instead of JavaScript! If I find something interesting, I want to find out and test it. See what has gotten better or worse.</p>
                <p>Besides my passion for programming, I am also interested in hardware. For example, I have built my own PC and home server. That very server you are accessing right now.</p>
                <p>That’s it. If you want to know more about me or Maurice Software Solutions, please navigate to the feedback or contact page to ask your question</p>", new Guid("952dbfe4-42f0-46ac-87cd-8fc1f8acf862"), "Body2" },
                    { new Guid("67b4c6ce-310e-43bc-a7cf-c2e128a16b20"), "<strong>Who is Maurice?</strong>", new Guid("952dbfe4-42f0-46ac-87cd-8fc1f8acf862"), "Header2" },
                    { new Guid("3359c3fb-f0a1-411a-9864-497757110dd6"), "<p>Maurice Software Solutions was created to showcase my programming skills and to have some fun. Aside from that there is handy and fun functionality to be found like a fully-fledged, unlimited personal cloud storage system and a chatroom. And those are just the things I am currently working on. I am dedicated to improving Maurice Software Solutions as a whole regularly whilst adding cool new features.</p>", new Guid("952dbfe4-42f0-46ac-87cd-8fc1f8acf862"), "Body1" },
                    { new Guid("01946315-59c5-43b9-8721-1bd17b508c00"), "<strong>What is MSS?</strong>", new Guid("952dbfe4-42f0-46ac-87cd-8fc1f8acf862"), "Header1" },
                    { new Guid("7c958ec2-f9a3-4f2c-93b0-3384c67ae48b"), "<strong>Contact information</strong>", new Guid("e080f91f-8487-4515-93a0-e5b50060ed3c"), "Header1" },
                    { new Guid("39aea878-58a0-449d-bf2b-8a8c7e19c91b"), "<h4>About me and MSS</h4>", new Guid("952dbfe4-42f0-46ac-87cd-8fc1f8acf862"), "Title1" }
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
                name: "PageSections");
        }
    }
}
