using Microsoft.EntityFrameworkCore.Migrations;

namespace Ehpad.ORM.Migrations
{
    public partial class DataInitialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PersonTypes",
                columns: new[] { "Id", "Label" },
                values: new object[] { 1, "Personnel" });

            migrationBuilder.InsertData(
                table: "PersonTypes",
                columns: new[] { "Id", "Label" },
                values: new object[] { 2, "Résident" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PersonTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PersonTypes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
