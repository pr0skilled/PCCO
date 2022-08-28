using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCCO.DataAccess.Migrations
{
    public partial class appUserModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_IndividualData_IndividualDataId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IndividualDataId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IndividualDataId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentificationCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkPosition",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Workplace",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdentificationCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WorkPosition",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Workplace",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "IndividualDataId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IndividualDataId",
                table: "AspNetUsers",
                column: "IndividualDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_IndividualData_IndividualDataId",
                table: "AspNetUsers",
                column: "IndividualDataId",
                principalTable: "IndividualData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
