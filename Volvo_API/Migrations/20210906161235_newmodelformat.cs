using Microsoft.EntityFrameworkCore.Migrations;

namespace Volvo_API.Migrations
{
    public partial class newmodelformat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModelId",
                table: "Trucks",
                newName: "TruckModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Trucks_TruckModelId",
                table: "Trucks",
                column: "TruckModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trucks_TruckModels_TruckModelId",
                table: "Trucks",
                column: "TruckModelId",
                principalTable: "TruckModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trucks_TruckModels_TruckModelId",
                table: "Trucks");

            migrationBuilder.DropIndex(
                name: "IX_Trucks_TruckModelId",
                table: "Trucks");

            migrationBuilder.RenameColumn(
                name: "TruckModelId",
                table: "Trucks",
                newName: "ModelId");
        }
    }
}
