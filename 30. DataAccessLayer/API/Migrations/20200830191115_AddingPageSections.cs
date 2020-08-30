using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MTS.BL.API.Migrations
{
    public partial class AddingPageSections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PageSections",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PageName = table.Column<string>(nullable: true),
                    Header = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageSections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DALParagraph",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    DALPageSectionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DALParagraph", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DALParagraph_PageSections_DALPageSectionId",
                        column: x => x.DALPageSectionId,
                        principalTable: "PageSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DALParagraph_DALPageSectionId",
                table: "DALParagraph",
                column: "DALPageSectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DALParagraph");

            migrationBuilder.DropTable(
                name: "PageSections");
        }
    }
}
