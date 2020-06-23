using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class addedIsAdmitted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmitted",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmitted",
                table: "AspNetUsers");
        }
    }
}
