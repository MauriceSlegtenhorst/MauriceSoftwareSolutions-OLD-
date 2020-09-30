using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MTS.BL.API.Migrations
{
    public partial class creditChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "126bccb1-67de-4865-8359-25f1eaf2c408");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2aa69a56-324d-4b2e-858f-e12421a9657f");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "3ac0d468-eaf7-45dc-a817-ae5224276540", "ead5b150-ca04-4bce-a55d-83cf739dc7d8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "3cd4f0f2-67f6-43cf-8dbd-e47bf7ca5964", "4c70af36-f0fc-457c-aede-1b0ec2247518" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "7695a43b-9e4f-43a4-a6b7-bdf5fd1b9ebb", "ead5b150-ca04-4bce-a55d-83cf739dc7d8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "a797f750-7595-4b14-8490-964282d9792f", "99e1d4e1-94b2-4ad0-9b63-56779bab8277" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "c5a70434-3e5f-4dd9-86e4-e80c501c1935", "fdf58f7d-b2ba-443a-84c1-f4ece9b839b5" });

            migrationBuilder.DeleteData(
                table: "Credits",
                keyColumn: "CreditId",
                keyValue: new Guid("78d0bc31-c3d1-4e6e-b8e0-3c9d9ce2c340"));

            migrationBuilder.DeleteData(
                table: "Credits",
                keyColumn: "CreditId",
                keyValue: new Guid("f386ce3e-8087-4cb8-bf2a-b541f0edd169"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("0648cb01-e522-41fa-be4e-f3c7664e1ac4"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("110248e6-4a87-4a86-88a9-6b38e7577414"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("179f4afb-7f98-416e-aea8-4d7eeb65e0d5"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("1964c609-c7b6-4b1f-ab06-653c1fa71a2b"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("1a9ece75-da90-41db-8d6b-0f041e962b23"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("6c8e8c7f-4955-4d02-a8d7-d8f4900277a4"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("71067f26-7cf1-4aba-a9d5-c101b0725633"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("852bf666-646e-4c1a-bd24-e80b78da167d"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("c2caf1ac-6e69-4a25-b1ce-dc6e5d1f98f4"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("d672d408-624b-425b-84c0-c09779aaad42"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("dd640107-8672-4103-83dd-bf67259ee3c4"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("eb61a4f0-2817-444e-90f8-79d16b2f4529"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("f8c48f69-4c87-4d50-8475-fca56da175da"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c70af36-f0fc-457c-aede-1b0ec2247518");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99e1d4e1-94b2-4ad0-9b63-56779bab8277");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ead5b150-ca04-4bce-a55d-83cf739dc7d8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdf58f7d-b2ba-443a-84c1-f4ece9b839b5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ac0d468-eaf7-45dc-a817-ae5224276540");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cd4f0f2-67f6-43cf-8dbd-e47bf7ca5964");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7695a43b-9e4f-43a4-a6b7-bdf5fd1b9ebb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a797f750-7595-4b14-8490-964282d9792f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c5a70434-3e5f-4dd9-86e4-e80c501c1935");

            migrationBuilder.DeleteData(
                table: "CreditCategories",
                keyColumn: "CreditCategoryId",
                keyValue: new Guid("02e668f8-f7ca-4f8a-b033-09f61878f803"));

            migrationBuilder.DeleteData(
                table: "PageSections",
                keyColumn: "PageSectionId",
                keyValue: new Guid("b8505101-d148-4869-ba87-0023a8cf634e"));

            migrationBuilder.DeleteData(
                table: "PageSections",
                keyColumn: "PageSectionId",
                keyValue: new Guid("c6e63cbd-588e-4283-a410-3a489c979525"));

            migrationBuilder.DropColumn(
                name: "GotFromWebsite",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "MadeByWebsite",
                table: "Credits");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b6383b6-09b2-4694-857f-97e43e8337c3", "073ae7bf-4981-456e-8095-e947fc5faea0", "administrator", "ADMINISTRATOR" },
                    { "35e74155-6145-4f2f-a517-1ef43a8f2e9a", "6eaaa42b-a89d-4aff-aea9-db11c84697b1", "privilegedemployee", "PRIVILEGEDEMPLOYEE" },
                    { "89b2c433-c5ab-468a-a1b8-e00356311f01", "49492850-7207-4d42-9a4c-485da3803bb7", "employee", "EMPLOYEE" },
                    { "bf87512d-438b-4dab-a4ff-5857c12012f0", "baa82893-4839-48d1-ad9c-01e29f4b7dba", "volenteer", "VOLENTEER" },
                    { "8f1cb419-6140-4e39-84fa-d22b1205b3dc", "c4810578-bf65-41a4-8009-5fc8b2c0c41f", "privilegeduser", "PRIVILEGEDUSER" },
                    { "35196f9b-aab8-425a-ab74-37441ad84eaf", "5becea24-3184-49ea-b585-b515fce47598", "standarduser", "STANDARDUSER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Affix", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsAdmitted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4e9d76b7-9cba-4e17-be8a-3bafad8ceeee", 0, null, "f27e3c2c-eacc-4878-aea5-60df61e93828", "mauricesoftwaresolution@outlook.com", true, "Maurice", true, "Slegtenhorst", true, null, "MAURICESOFTWARESOLUTION@OUTLOOK.COM", "MAURICESOFTWARESOLUTION@OUTLOOK.COM", "AQAAAAEAACcQAAAAEGRNOSr2QGTPHh3xWMliVQn9DWkpzhipyAut+hGFl+0YMcgeD7rHTgKVkHh8qcZgmw==", "0645377536", true, "72b75e07-9663-408f-8363-aba387022d01", false, "mauricesoftwaresolution@outlook.com" },
                    { "c04b5af8-262e-497c-993f-1a46d4d1c977", 0, null, "5aff2c2e-6045-4831-8f92-594e32645a02", "hanneke.slegtenhorst1@gmail.com", true, "Hanneke", true, "Slegtenhorst", true, null, "HANNEKE.SLEGTENHORST1@GMAIL.COM", "HANNEKE.SLEGTENHORST1@GMAIL.COM", "AQAAAAEAACcQAAAAEGRNOSr2QGTPHh3xWMliVQn9DWkpzhipyAut+hGFl+0YMcgeD7rHTgKVkHh8qcZgmw==", "060025553912", true, "a31ad130-2d76-4bd6-837a-7f44db2ca2b3", false, "hanneke.slegtenhorst1@gmail.com" },
                    { "29e60a21-ff54-4182-bddc-8b4239335a6e", 0, null, "4840e617-4530-40d4-aa35-ea6901e75422", "privilegedemployee01@mss.nl", true, "PrivilegedEmployee_01", true, "None", true, null, "PRIVILEGEDEMPLOYEE01@MSS.NL", "PRIVILEGEDEMPLOYEE01@MSS.NL", "AQAAAAEAACcQAAAAEGRNOSr2QGTPHh3xWMliVQn9DWkpzhipyAut+hGFl+0YMcgeD7rHTgKVkHh8qcZgmw==", "060035678950", true, "16674d82-7167-4b5d-9cdf-fc5a75116607", false, "privilegedemployee01@mss.nl" },
                    { "3b359123-4317-44b6-b068-f204a97c3c73", 0, null, "f353699d-3f17-41ff-8998-e491b0c6fa6f", "employee01@mss.nl", true, "Employee_01", true, "None", true, null, "EMPLOYEE01@MSS.NL", "EMPLOYEE01@MTS.NL", "AQAAAAEAACcQAAAAEGRNOSr2QGTPHh3xWMliVQn9DWkpzhipyAut+hGFl+0YMcgeD7rHTgKVkHh8qcZgmw==", "060054542051", true, "0ef5a3d7-7704-40f1-854a-1350619f71ce", false, "Employee01@MTS.nl" },
                    { "a6432b3b-b8ad-454d-9234-6d5eb53ec6cd", 0, null, "bbdd05d6-b3b8-4099-ad12-24b9dd68077f", "standarduser01@mts.nl", true, "StandardUser_01", true, "None", true, null, "STANDARDUSER01@MSS.NL", "STANDARDUSER01@MSS.NL", "AQAAAAEAACcQAAAAEGRNOSr2QGTPHh3xWMliVQn9DWkpzhipyAut+hGFl+0YMcgeD7rHTgKVkHh8qcZgmw==", "060001959870", true, "f93c5d6f-140b-4803-a370-9299ab6b6b2e", false, "standarduser01@mts.nl" }
                });

            migrationBuilder.InsertData(
                table: "CreditCategories",
                columns: new[] { "CreditCategoryId", "Description", "SubTitle", "Title" },
                values: new object[,]
                {
                    { new Guid("670a3b19-5152-49c1-bf77-a05487852086"), null, "<h5>Sources that made UI development easier</h5>", "<h4>Don't reinvent the wheel<h4>" },
                    { new Guid("2fc7c2b9-2bf2-4e98-9bf1-7f7238aebcfd"), null, "<h5>Sources that helped me gaining knoledge about programming related subjects</h5>", "<h4>Food for the brain<h4>" }
                });

            migrationBuilder.InsertData(
                table: "PageSections",
                columns: new[] { "PageSectionId", "PageRoute", "SectionNumber" },
                values: new object[,]
                {
                    { new Guid("67c96654-4453-4a82-855f-bc442ca4ccde"), "Index", 0 },
                    { new Guid("fcce9664-36a0-43ad-94b3-2f48f914b808"), "Index", 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "a6432b3b-b8ad-454d-9234-6d5eb53ec6cd", "35196f9b-aab8-425a-ab74-37441ad84eaf" },
                    { "29e60a21-ff54-4182-bddc-8b4239335a6e", "35e74155-6145-4f2f-a517-1ef43a8f2e9a" },
                    { "c04b5af8-262e-497c-993f-1a46d4d1c977", "0b6383b6-09b2-4694-857f-97e43e8337c3" },
                    { "4e9d76b7-9cba-4e17-be8a-3bafad8ceeee", "0b6383b6-09b2-4694-857f-97e43e8337c3" },
                    { "3b359123-4317-44b6-b068-f204a97c3c73", "89b2c433-c5ab-468a-a1b8-e00356311f01" }
                });

            migrationBuilder.InsertData(
                table: "Credits",
                columns: new[] { "CreditId", "CreditCategoryFK", "Description", "GotFrom", "LinkToImage", "MadeBy", "SubTitle", "Title" },
                values: new object[,]
                {
                    { new Guid("3dc99482-c028-4e0e-a00b-70d581682c80"), new Guid("670a3b19-5152-49c1-bf77-a05487852086"), "<p>Most, if not all icons came from this provider. This font came with the project when it was created. I kept it for its ease of use.</p>", "Got from: <a href='https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor'>Blazor WebAssembly project builder</a>", "https://img.stackshare.io/service/3029/iconic.png", "Made by: <a href='https://useiconic.com/open'>Open-Iconic</a>", "<h5>Provider of fonts and icons</h5>", "<h4>Open Iconic</h4>" },
                    { new Guid("a1a2833d-d9c9-4688-8a88-e0e040626a9f"), new Guid("2fc7c2b9-2bf2-4e98-9bf1-7f7238aebcfd"), "<p>Tim Corey provides many educational video's about programming in general but focused around C#. His goal is to make learning C# easier. Awesome guy.</p>", "Got from: searching for tutorial video's on <a href='https://www.youtube.com'>YouTube</a> about C#", "https://avatars3.githubusercontent.com/u/1839873?s=400&v=4", "Made by: <a href='https://www.youtube.com/timcorey'>Tim Corey's YouTube channel</a>", "<h5>Youtuber with the best C# how-to video's</h5>", "<h4>Tim Corey</h4>" },
                    { new Guid("6878653a-1375-4e2b-a77c-81ba248a221e"), new Guid("670a3b19-5152-49c1-bf77-a05487852086"), "<p>Some tasks while creating an UI are repetative. Syncfusion helps by providing components for repetative use.</p>", "Got from: <a href='https://www.syncfusion.com/products/communitylicense'>Syncfusion community license</a>", "https://cdn.syncfusion.com/content/images/Logo/Logo_150dpi.png", "Made by: <a href='https://www.syncfusion.com/blazor-components'>Syncfusion website</a>", "<h5>Easy to use premade Blazor components</h5>", "<h4>Syncfusion</h4>" }
                });

            migrationBuilder.InsertData(
                table: "SectionParts",
                columns: new[] { "SectionPartId", "Content", "PageSectionFK", "Type" },
                values: new object[,]
                {
                    { new Guid("ff68faf3-4221-4dcd-a248-ec3260a84e39"), "<strong>Who is Maurice?</strong>", new Guid("67c96654-4453-4a82-855f-bc442ca4ccde"), "Header2" },
                    { new Guid("bb11c814-21f0-436b-80bd-ca619a5495ae"), @"<p>I am an enthusiastic man with a strong passion for programming. Social and friendly going. Coding has been my hobby from an early age. When I was 13, I made my first program in Visual Basic. A slot machine where there were secret options to get infinite money for example. Later, around the age of 18, I started working with Java, XML and Android Studio. With this I built a number of Android apps including an applocker. This app allowed the user to choose which apps and services needed an additional password or fingerprint to be used.</p>
                <p>Friends and especially family regularly ask me for help with electronics and software related matters. I think this is because I have been busy with software and hardware practically my whole life.</p>
                <p>Marketing and commerce seemed to be my career choice for a long time. During my higher professional education, Commercial Economics, I found out that this did not meet my expectations.</p>
                <p>At one point I ended up at ITvitae and started working on my C# programming skills. This went well for me because Java is similar in syntax to C#. Here I have made several complicated programs with C# and related languages such as SQL, HTML XAML, JavaScript and CSS. At ITvitae I have greatly improved my software development skills. After about a year I have successfully completed the process.</p>
                <p>My interests lie in the latest techniques in software development and electronics. In particular what advantages and disadvantages there are. For example, I can get enthusiastic about developments such as Blazor. This offers such cool options within the internet landscape. For example, the website can be installed as a local application and C# can be used instead of JavaScript! If I find something interesting, I want to find out and test it. See what has gotten better or worse.</p>
                <p>Besides my passion for programming, I am also interested in hardware. For example, I have built my own PC and home server. That very server you are accessing right now.</p>
                <p>That’s it. If you want to know more about me or Maurice Software Solutions, please navigate to the feedback or contact page to ask your question</p>", new Guid("67c96654-4453-4a82-855f-bc442ca4ccde"), "Body2" },
                    { new Guid("68daf39f-05d9-4822-90ae-e1177a38b396"), "<h4>Maurice Slegtenhorst</h4>", new Guid("fcce9664-36a0-43ad-94b3-2f48f914b808"), "Title1" },
                    { new Guid("347e2eff-48f6-4ac7-a7f4-735383e5f2e8"), "<h5>C# Software Developer</h5>", new Guid("fcce9664-36a0-43ad-94b3-2f48f914b808"), "SubTitle1" },
                    { new Guid("591fb1ce-370c-408e-b241-8d11f08c1700"), "<strong>What is MSS?</strong>", new Guid("67c96654-4453-4a82-855f-bc442ca4ccde"), "Header1" },
                    { new Guid("48ce8771-c428-4f4e-b4d0-a1b5b4022e37"), "<div class=\"row\"><div class=\"col - 6\">Phone number:</div><div class=\"col - 6\">+31 645377536</div></div><div class=\"row\"><div class=\"col - 6\">Personal e-mail:</div><div class=\"col - 6\">maurice.slegtenhorst@outlook.com</div></div><div class=\"row\"><div class=\"col - 6\">Student e-mail</div><div class=\"col - 6\">maurice.slegtenhorst@itvitaelearning.nl</div></div></p>", new Guid("fcce9664-36a0-43ad-94b3-2f48f914b808"), "Body1" },
                    { new Guid("16db04af-b2c7-409d-b56a-ad12b5f81149"), "<strong>What can he do?</strong>", new Guid("fcce9664-36a0-43ad-94b3-2f48f914b808"), "Header2" },
                    { new Guid("03b8a39b-e700-441d-ab1b-4918a2b58c10"), "<p>C#, JavaScript, SQL, HTML5, CSS3, XAML and XML</p>", new Guid("fcce9664-36a0-43ad-94b3-2f48f914b808"), "Body2" },
                    { new Guid("3df17a45-eaf7-41ec-8aa6-e7f250e8b15e"), "<strong>Maurice in a nutshell</strong>", new Guid("fcce9664-36a0-43ad-94b3-2f48f914b808"), "Header3" },
                    { new Guid("9f5a6b7a-b9ea-4b13-8d66-567ff541b9a5"), "<p>Born on 27th of april 1991 and living in The Netherlands sinds then. Loves coding and fiddling with electronics. Likes to go for a jog or socialize</p>", new Guid("fcce9664-36a0-43ad-94b3-2f48f914b808"), "Body3" },
                    { new Guid("810f81e8-b851-4992-9b9a-84833182dfe5"), "<h4>About me and MSS</h4>", new Guid("67c96654-4453-4a82-855f-bc442ca4ccde"), "Title1" },
                    { new Guid("da19d6ba-2a2c-43d6-b4d1-8138f78fc3c1"), "<p>Maurice Software Solutions was created to showcase my programming skills and to have some fun. Aside from that there is handy and fun functionality to be found like a fully-fledged, unlimited personal cloud storage system and a chatroom. And those are just the things I am currently working on. I am dedicated to improving Maurice Software Solutions as a whole regularly whilst adding cool new features.</p>", new Guid("67c96654-4453-4a82-855f-bc442ca4ccde"), "Body1" },
                    { new Guid("36540420-e487-41bb-bfa5-f25874ffb415"), "<strong>Contact information</strong>", new Guid("fcce9664-36a0-43ad-94b3-2f48f914b808"), "Header1" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f1cb419-6140-4e39-84fa-d22b1205b3dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf87512d-438b-4dab-a4ff-5857c12012f0");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "29e60a21-ff54-4182-bddc-8b4239335a6e", "35e74155-6145-4f2f-a517-1ef43a8f2e9a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "3b359123-4317-44b6-b068-f204a97c3c73", "89b2c433-c5ab-468a-a1b8-e00356311f01" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "4e9d76b7-9cba-4e17-be8a-3bafad8ceeee", "0b6383b6-09b2-4694-857f-97e43e8337c3" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "a6432b3b-b8ad-454d-9234-6d5eb53ec6cd", "35196f9b-aab8-425a-ab74-37441ad84eaf" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "c04b5af8-262e-497c-993f-1a46d4d1c977", "0b6383b6-09b2-4694-857f-97e43e8337c3" });

            migrationBuilder.DeleteData(
                table: "Credits",
                keyColumn: "CreditId",
                keyValue: new Guid("3dc99482-c028-4e0e-a00b-70d581682c80"));

            migrationBuilder.DeleteData(
                table: "Credits",
                keyColumn: "CreditId",
                keyValue: new Guid("6878653a-1375-4e2b-a77c-81ba248a221e"));

            migrationBuilder.DeleteData(
                table: "Credits",
                keyColumn: "CreditId",
                keyValue: new Guid("a1a2833d-d9c9-4688-8a88-e0e040626a9f"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("03b8a39b-e700-441d-ab1b-4918a2b58c10"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("16db04af-b2c7-409d-b56a-ad12b5f81149"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("347e2eff-48f6-4ac7-a7f4-735383e5f2e8"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("36540420-e487-41bb-bfa5-f25874ffb415"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("3df17a45-eaf7-41ec-8aa6-e7f250e8b15e"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("48ce8771-c428-4f4e-b4d0-a1b5b4022e37"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("591fb1ce-370c-408e-b241-8d11f08c1700"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("68daf39f-05d9-4822-90ae-e1177a38b396"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("810f81e8-b851-4992-9b9a-84833182dfe5"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("9f5a6b7a-b9ea-4b13-8d66-567ff541b9a5"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("bb11c814-21f0-436b-80bd-ca619a5495ae"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("da19d6ba-2a2c-43d6-b4d1-8138f78fc3c1"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("ff68faf3-4221-4dcd-a248-ec3260a84e39"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b6383b6-09b2-4694-857f-97e43e8337c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35196f9b-aab8-425a-ab74-37441ad84eaf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35e74155-6145-4f2f-a517-1ef43a8f2e9a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89b2c433-c5ab-468a-a1b8-e00356311f01");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29e60a21-ff54-4182-bddc-8b4239335a6e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b359123-4317-44b6-b068-f204a97c3c73");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4e9d76b7-9cba-4e17-be8a-3bafad8ceeee");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a6432b3b-b8ad-454d-9234-6d5eb53ec6cd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c04b5af8-262e-497c-993f-1a46d4d1c977");

            migrationBuilder.DeleteData(
                table: "CreditCategories",
                keyColumn: "CreditCategoryId",
                keyValue: new Guid("2fc7c2b9-2bf2-4e98-9bf1-7f7238aebcfd"));

            migrationBuilder.DeleteData(
                table: "CreditCategories",
                keyColumn: "CreditCategoryId",
                keyValue: new Guid("670a3b19-5152-49c1-bf77-a05487852086"));

            migrationBuilder.DeleteData(
                table: "PageSections",
                keyColumn: "PageSectionId",
                keyValue: new Guid("67c96654-4453-4a82-855f-bc442ca4ccde"));

            migrationBuilder.DeleteData(
                table: "PageSections",
                keyColumn: "PageSectionId",
                keyValue: new Guid("fcce9664-36a0-43ad-94b3-2f48f914b808"));

            migrationBuilder.AddColumn<string>(
                name: "GotFromWebsite",
                table: "Credits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MadeByWebsite",
                table: "Credits",
                type: "nvarchar(max)",
                nullable: true);

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
        }
    }
}
