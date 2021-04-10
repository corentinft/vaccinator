using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ehpad.ORM.Migrations
{
    public partial class Vaccinate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "VaccineTypes",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Vaccines",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "VaccineTypeId",
                table: "Vaccines",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BatchNumber",
                table: "Vaccinates",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Vaccinates",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Vaccinates",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RecallDate",
                table: "Vaccinates",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "VaccineId",
                table: "Vaccinates",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vaccines_VaccineTypeId",
                table: "Vaccines",
                column: "VaccineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinates_PersonId",
                table: "Vaccinates",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinates_VaccineId",
                table: "Vaccinates",
                column: "VaccineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccinates_Persons_PersonId",
                table: "Vaccinates",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccinates_Vaccines_VaccineId",
                table: "Vaccinates",
                column: "VaccineId",
                principalTable: "Vaccines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccines_VaccineTypes_VaccineTypeId",
                table: "Vaccines",
                column: "VaccineTypeId",
                principalTable: "VaccineTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vaccinates_Persons_PersonId",
                table: "Vaccinates");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccinates_Vaccines_VaccineId",
                table: "Vaccinates");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccines_VaccineTypes_VaccineTypeId",
                table: "Vaccines");

            migrationBuilder.DropIndex(
                name: "IX_Vaccines_VaccineTypeId",
                table: "Vaccines");

            migrationBuilder.DropIndex(
                name: "IX_Vaccinates_PersonId",
                table: "Vaccinates");

            migrationBuilder.DropIndex(
                name: "IX_Vaccinates_VaccineId",
                table: "Vaccinates");

            migrationBuilder.DropColumn(
                name: "Label",
                table: "VaccineTypes");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Vaccines");

            migrationBuilder.DropColumn(
                name: "VaccineTypeId",
                table: "Vaccines");

            migrationBuilder.DropColumn(
                name: "BatchNumber",
                table: "Vaccinates");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Vaccinates");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Vaccinates");

            migrationBuilder.DropColumn(
                name: "RecallDate",
                table: "Vaccinates");

            migrationBuilder.DropColumn(
                name: "VaccineId",
                table: "Vaccinates");
        }
    }
}
