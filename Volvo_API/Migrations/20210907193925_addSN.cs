using Microsoft.EntityFrameworkCore.Migrations;

namespace Volvo_API.Migrations
{
    public partial class addSN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "Trucks",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "Trucks");
        }
    }
}
