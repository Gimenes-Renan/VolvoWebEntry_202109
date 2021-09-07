using Microsoft.EntityFrameworkCore.Migrations;

namespace Volvo_API.Migrations
{
    public partial class InitialSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TruckModels",
                columns: new[] { "Id", "Model" },
                values: new object[,]
                {
                    { 1L, "FH" },
                    { 2L, "FM" }
                });

            migrationBuilder.InsertData(
                table: "Trucks",
                columns: new[] { "Id", "FabricationYear", "ModelId", "ModelYear" },
                values: new object[,]
                {
                    { 1L, 2021, 1L, 2021 },
                    { 2L, 2021, 1L, 2022 },
                    { 3L, 2021, 2L, 2021 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TruckModels",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "TruckModels",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}
