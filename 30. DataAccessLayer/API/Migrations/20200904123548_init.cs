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
                table: "PageSections",
                columns: new[] { "PageSectionId", "PageRoute" },
                values: new object[] { new Guid("7d8aa5ed-bb0a-4ca8-a9bf-46085cec9369"), "Index" });

            migrationBuilder.InsertData(
                table: "PageSections",
                columns: new[] { "PageSectionId", "PageRoute" },
                values: new object[] { new Guid("814c1475-113c-4c3c-bd9a-a4fbf36939b4"), "Index" });

            migrationBuilder.InsertData(
                table: "SectionParts",
                columns: new[] { "SectionPartId", "Content", "PageSectionFK", "Type" },
                values: new object[,]
                {
                    { new Guid("17725189-47db-46dd-a582-3f4680d4e01a"), "<h4>About me and MSS</h4>", new Guid("7d8aa5ed-bb0a-4ca8-a9bf-46085cec9369"), "Title1" },
                    { new Guid("94aabd8d-5a57-40e6-ab24-90462c6cedc6"), "<strong>What is MSS?</strong>", new Guid("7d8aa5ed-bb0a-4ca8-a9bf-46085cec9369"), "Header1" },
                    { new Guid("0f37ae00-c67f-4832-bee8-7f1d51272c38"), "<p>Maurice Software Solutions was created to showcase my programming skills and to have some fun. Aside from that there is handy and fun functionality to be found like a fully-fledged, unlimited personal cloud storage system and a chatroom. And those are just the things I am currently working on. I am dedicated to improving Maurice Software Solutions as a whole regularly whilst adding cool new features.</p>", new Guid("7d8aa5ed-bb0a-4ca8-a9bf-46085cec9369"), "Body1" },
                    { new Guid("1e2c0185-8676-48e1-ba75-0c28bdf3a9f7"), "<strong>Who is Maurice?</strong>", new Guid("7d8aa5ed-bb0a-4ca8-a9bf-46085cec9369"), "Header2" },
                    { new Guid("dd2c5219-6dff-496b-975e-c7a2c234dabf"), @"<p>I am an enthusiastic man with a strong passion for programming. Social and friendly going. Coding has been my hobby from an early age. When I was 13, I made my first program in Visual Basic. A slot machine where there were secret options to get infinite money for example. Later, around the age of 18, I started working with Java, XML and Android Studio. With this I built a number of Android apps including an applocker. This app allowed the user to choose which apps and services needed an additional password or fingerprint to be used.</p>
                <p>Friends and especially family regularly ask me for help with electronics and software related matters. I think this is because I have been busy with software and hardware practically my whole life.</p>
                <p>Marketing and commerce seemed to be my career choice for a long time. During my higher professional education, Commercial Economics, I found out that this did not meet my expectations.</p>
                <p>At one point I ended up at ITvitae and started working on my C# programming skills. This went well for me because Java is similar in syntax to C#. Here I have made several complicated programs with C# and related languages such as SQL, HTML XAML, JavaScript and CSS. At ITvitae I have greatly improved my software development skills. After about a year I have successfully completed the process.</p>
                <p>My interests lie in the latest techniques in software development and electronics. In particular what advantages and disadvantages there are. For example, I can get enthusiastic about developments such as Blazor. This offers such cool options within the internet landscape. For example, the website can be installed as a local application and C# can be used instead of JavaScript! If I find something interesting, I want to find out and test it. See what has gotten better or worse.</p>
                <p>Besides my passion for programming, I am also interested in hardware. For example, I have built my own PC and home server. That very server you are accessing right now.</p>
                <p>That’s it. If you want to know more about me or Maurice Software Solutions, please navigate to the feedback or contact page to ask your question</p>", new Guid("7d8aa5ed-bb0a-4ca8-a9bf-46085cec9369"), "Body2" },
                    { new Guid("be6340aa-b3b2-40e7-b714-e326b3a2d1a1"), "<h4>Maurice Slegtenhorst</h4>", new Guid("814c1475-113c-4c3c-bd9a-a4fbf36939b4"), "Title1" },
                    { new Guid("5a62269a-200e-4369-9bf1-3bbb6f583533"), "<h5>C# Software Developer</h5>", new Guid("814c1475-113c-4c3c-bd9a-a4fbf36939b4"), "SubTitle1" },
                    { new Guid("015bc7a4-ca99-4a35-992a-4684cda74947"), "<strong>Contact information</strong>", new Guid("814c1475-113c-4c3c-bd9a-a4fbf36939b4"), "Header1" },
                    { new Guid("a176b1c9-128c-4eda-aecc-4ba06e2676bb"), "<div class=\"row\"><div class=\"col - 6\">Phone number:</div><div class=\"col - 6\">+31 645377536</div></div><div class=\"row\"><div class=\"col - 6\">Personal e-mail:</div><div class=\"col - 6\">maurice.slegtenhorst@outlook.com</div></div><div class=\"row\"><div class=\"col - 6\">Student e-mail</div><div class=\"col - 6\">maurice.slegtenhorst@itvitaelearning.nl</div></div></p>", new Guid("814c1475-113c-4c3c-bd9a-a4fbf36939b4"), "Body1" },
                    { new Guid("0a7ddc1b-f0af-42c6-b4fe-af2cef21991e"), "<strong>What can he do?</strong>", new Guid("814c1475-113c-4c3c-bd9a-a4fbf36939b4"), "Header2" },
                    { new Guid("5ec5b944-f7fb-4dd9-8424-606316770306"), "<p>C#, JavaScript, SQL, HTML5, CSS3, XAML and XML</p>", new Guid("814c1475-113c-4c3c-bd9a-a4fbf36939b4"), "Body2" },
                    { new Guid("f5c26e53-abb4-4b0c-b4d1-376809c9a3bd"), "<strong>Maurice in a nutshell</strong>", new Guid("814c1475-113c-4c3c-bd9a-a4fbf36939b4"), "Header3" },
                    { new Guid("38d7d41d-0326-4cb1-ae2c-a4d9aafa12bd"), "<p>Born on 27th of april 1991 and living in The Netherlands sinds then. Loves coding and fiddling with electronics. Likes to go for a jog or socialize</p>", new Guid("814c1475-113c-4c3c-bd9a-a4fbf36939b4"), "Body3" }
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
