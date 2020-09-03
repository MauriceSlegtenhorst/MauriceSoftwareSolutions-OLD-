using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MTS.BL.API.Migrations
{
    public partial class changeSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("09b30f2f-ef08-44f7-94bd-560cbbb70250"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("14317faa-dd85-4313-b4c8-8ffa1d0bc5df"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("b6eac4cf-5da0-43d2-a5f0-c5db083c88fd"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("e000af2d-b5cc-494e-bf85-54514cda3856"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("e20ccceb-c95a-440b-915c-1a95857784f4"));

            migrationBuilder.DeleteData(
                table: "PageSections",
                keyColumn: "PageSectionId",
                keyValue: new Guid("011531a2-e4e6-49a3-aebd-cc22348ae5f8"));

            migrationBuilder.InsertData(
                table: "PageSections",
                columns: new[] { "PageSectionId", "PageRoute" },
                values: new object[] { new Guid("9257ff20-ba3e-4b03-b236-86e15f3f3fde"), "Index" });

            migrationBuilder.InsertData(
                table: "SectionParts",
                columns: new[] { "SectionPartId", "Content", "PageSectionFK", "Type" },
                values: new object[,]
                {
                    { new Guid("c86d8007-2c0d-4b11-98e2-335339eb8caa"), "<h4>About me and MSS</h4>", new Guid("9257ff20-ba3e-4b03-b236-86e15f3f3fde"), "Title1" },
                    { new Guid("f34f92bb-7225-4ead-9b91-1d3345225ff3"), "<strong>What is MSS?</strong>", new Guid("9257ff20-ba3e-4b03-b236-86e15f3f3fde"), "Header1" },
                    { new Guid("42439b57-9c24-40b2-a130-8ce265b5504c"), "<p>Maurice Software Solutions was created to showcase my programming skills and to have some fun. Aside from that there is handy and fun functionality to be found like a fully-fledged, unlimited personal cloud storage system and a chatroom. And those are just the things I am currently working on. I am dedicated to improving Maurice Software Solutions as a whole regularly whilst adding cool new features.</p>", new Guid("9257ff20-ba3e-4b03-b236-86e15f3f3fde"), "Body1" },
                    { new Guid("e62201ef-61fa-4ae9-b717-7d973caf2f5b"), "<strong>Who is Maurice?</strong>", new Guid("9257ff20-ba3e-4b03-b236-86e15f3f3fde"), "Header2" },
                    { new Guid("ddbd8206-7791-4e74-8e5e-2f38e85b8f10"), @"<p>I am an enthusiastic man with a strong passion for programming. Social and friendly going. Coding has been my hobby from an early age. When I was 13, I made my first program in Visual Basic. A slot machine where there were secret options to get infinite money for example. Later, around the age of 18, I started working with Java, XML and Android Studio. With this I built a number of Android apps including an applocker. This app allowed the user to choose which apps and services needed an additional password or fingerprint to be used.</p>
                <p>Friends and especially family regularly ask me for help with electronics and software related matters. I think this is because I have been busy with software and hardware practically my whole life.</p>
                <p>Marketing and commerce seemed to be my career choice for a long time. During my higher professional education, Commercial Economics, I found out that this did not meet my expectations.</p>
                <p>At one point I ended up at ITvitae and started working on my C# programming skills. This went well for me because Java is similar in syntax to C#. Here I have made several complicated programs with C# and related languages such as SQL, HTML XAML, JavaScript and CSS. At ITvitae I have greatly improved my software development skills. After about a year I have successfully completed the process.</p>
                <p>My interests lie in the latest techniques in software development and electronics. In particular what advantages and disadvantages there are. For example, I can get enthusiastic about developments such as Blazor. This offers such cool options within the internet landscape. For example, the website can be installed as a local application and C# can be used instead of JavaScript! If I find something interesting, I want to find out and test it. See what has gotten better or worse.</p>
                <p>Besides my passion for programming, I am also interested in hardware. For example, I have built my own PC and home server. That very server you are accessing right now.</p>
                <p>That’s it. If you want to know more about me or Maurice Software Solutions, please navigate to the feedback or contact page to ask your question</p>", new Guid("9257ff20-ba3e-4b03-b236-86e15f3f3fde"), "Body2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("42439b57-9c24-40b2-a130-8ce265b5504c"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("c86d8007-2c0d-4b11-98e2-335339eb8caa"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("ddbd8206-7791-4e74-8e5e-2f38e85b8f10"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("e62201ef-61fa-4ae9-b717-7d973caf2f5b"));

            migrationBuilder.DeleteData(
                table: "SectionParts",
                keyColumn: "SectionPartId",
                keyValue: new Guid("f34f92bb-7225-4ead-9b91-1d3345225ff3"));

            migrationBuilder.DeleteData(
                table: "PageSections",
                keyColumn: "PageSectionId",
                keyValue: new Guid("9257ff20-ba3e-4b03-b236-86e15f3f3fde"));

            migrationBuilder.InsertData(
                table: "PageSections",
                columns: new[] { "PageSectionId", "PageRoute" },
                values: new object[] { new Guid("011531a2-e4e6-49a3-aebd-cc22348ae5f8"), "Index" });

            migrationBuilder.InsertData(
                table: "SectionParts",
                columns: new[] { "SectionPartId", "Content", "PageSectionFK", "Type" },
                values: new object[,]
                {
                    { new Guid("09b30f2f-ef08-44f7-94bd-560cbbb70250"), "About me and MSS", new Guid("011531a2-e4e6-49a3-aebd-cc22348ae5f8"), "Title1" },
                    { new Guid("14317faa-dd85-4313-b4c8-8ffa1d0bc5df"), "What is MSS?", new Guid("011531a2-e4e6-49a3-aebd-cc22348ae5f8"), "Header1" },
                    { new Guid("e20ccceb-c95a-440b-915c-1a95857784f4"), "Maurice Software Solutions was created to showcase my programming skills and to have some fun. Aside from that there is handy and fun functionality to be found like a fully-fledged, unlimited personal cloud storage system and a chatroom. And those are just the things I am currently working on. I am dedicated to improving Maurice Software Solutions as a whole regularly whilst adding cool new features.", new Guid("011531a2-e4e6-49a3-aebd-cc22348ae5f8"), "Body1" },
                    { new Guid("e000af2d-b5cc-494e-bf85-54514cda3856"), "Who is Maurice?", new Guid("011531a2-e4e6-49a3-aebd-cc22348ae5f8"), "Header2" },
                    { new Guid("b6eac4cf-5da0-43d2-a5f0-c5db083c88fd"), @"I am an enthusiastic man with a strong passion for programming. Social and friendly going. Coding has been my hobby from an early age. When I was 13, I made my first program in Visual Basic. A slot machine where there were secret options to get infinite money for example. Later, around the age of 18, I started working with Java, XML and Android Studio. With this I built a number of Android apps including an applocker. This app allowed the user to choose which apps and services needed an additional password or fingerprint to be used.

                Friends and especially family regularly ask me for help with electronics and software related matters. I think this is because I have been busy with software and hardware practically my whole life.

                Marketing and commerce seemed to be my career choice for a long time. During my higher professional education, Commercial Economics, I found out that this did not meet my expectations.

                At one point I ended up at ITvitae and started working on my C# programming skills. This went well for me because Java is similar in syntax to C#. Here I have made several complicated programs with C# and related languages such as SQL, HTML XAML, JavaScript and CSS. At ITvitae I have greatly improved my software development skills. After about a year I have successfully completed the process.

                My interests lie in the latest techniques in software development and electronics. In particular what advantages and disadvantages there are. For example, I can get enthusiastic about developments such as Blazor. This offers such cool options within the internet landscape. For example, the website can be installed as a local application and C# can be used instead of JavaScript! If I find something interesting, I want to find out and test it. See what has gotten better or worse.

                Besides my passion for programming, I am also interested in hardware. For example, I have built my own PC and home server. That very server you are accessing right now.

                That’s it. If you want to know more about me or Maurice Software Solutions, please navigate to the feedback or contact page to ask your question
                ", new Guid("011531a2-e4e6-49a3-aebd-cc22348ae5f8"), "Body2" }
                });
        }
    }
}
