using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ciocou_backend.Migrations
{
    public partial class AddedWinnerColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Winner",
                table: "Links",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Winner",
                table: "Links");
        }
    }
}
