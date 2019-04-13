using Microsoft.EntityFrameworkCore.Migrations;

namespace NuRen.Services.Migrations
{
    public partial class DropColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Videos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Videos",
                nullable: true);
        }
    }
}
