using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCCO.DataAccess.Migrations
{
    public partial class uniqueConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DisciplinaryActionCancellationReason",
                table: "Punishments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DisciplinaryActionCancellationDate",
                table: "Punishments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DateTime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CriminalActionCancellationReason",
                table: "Punishments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriminalActionCancellationDate",
                table: "Punishments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DateTime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsResident",
                table: "LegalEntityData",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdentificationCode",
                table: "LegalEntityData",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Series",
                table: "IndividualData",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "IdentificationCode",
                table: "IndividualData",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "IndividualData",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "DateTime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ArticleNumber",
                table: "CriminalArticles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CriminalRecordCancellationReason",
                table: "CorruptionRecords",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriminalRecordCancellationDate",
                table: "CorruptionRecords",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DateTime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CourtSentenceNumber",
                table: "CorruptionRecords",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CourtSentenceDate",
                table: "CorruptionRecords",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CourtSentenceApplyingDate",
                table: "CorruptionRecords",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime2");

            migrationBuilder.AlterColumn<string>(
                name: "CourtCaseNumber",
                table: "CorruptionRecords",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "AspNetUsers",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "DateTimeoffset",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LegalEntityData_IdentificationCode",
                table: "LegalEntityData",
                column: "IdentificationCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IssuingAuthorities_Code",
                table: "IssuingAuthorities",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IndividualData_IdentificationCode",
                table: "IndividualData",
                column: "IdentificationCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IndividualData_Series",
                table: "IndividualData",
                column: "Series",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CriminalArticles_ArticleNumber",
                table: "CriminalArticles",
                column: "ArticleNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CorruptionRecords_CourtCaseNumber",
                table: "CorruptionRecords",
                column: "CourtCaseNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CorruptionRecords_CourtSentenceNumber",
                table: "CorruptionRecords",
                column: "CourtSentenceNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LegalEntityData_IdentificationCode",
                table: "LegalEntityData");

            migrationBuilder.DropIndex(
                name: "IX_IssuingAuthorities_Code",
                table: "IssuingAuthorities");

            migrationBuilder.DropIndex(
                name: "IX_IndividualData_IdentificationCode",
                table: "IndividualData");

            migrationBuilder.DropIndex(
                name: "IX_IndividualData_Series",
                table: "IndividualData");

            migrationBuilder.DropIndex(
                name: "IX_CriminalArticles_ArticleNumber",
                table: "CriminalArticles");

            migrationBuilder.DropIndex(
                name: "IX_CorruptionRecords_CourtCaseNumber",
                table: "CorruptionRecords");

            migrationBuilder.DropIndex(
                name: "IX_CorruptionRecords_CourtSentenceNumber",
                table: "CorruptionRecords");

            migrationBuilder.AlterColumn<string>(
                name: "DisciplinaryActionCancellationReason",
                table: "Punishments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DisciplinaryActionCancellationDate",
                table: "Punishments",
                type: "DateTime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CriminalActionCancellationReason",
                table: "Punishments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriminalActionCancellationDate",
                table: "Punishments",
                type: "DateTime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsResident",
                table: "LegalEntityData",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "IdentificationCode",
                table: "LegalEntityData",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Series",
                table: "IndividualData",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "IdentificationCode",
                table: "IndividualData",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "IndividualData",
                type: "DateTime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "ArticleNumber",
                table: "CriminalArticles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CriminalRecordCancellationReason",
                table: "CorruptionRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriminalRecordCancellationDate",
                table: "CorruptionRecords",
                type: "DateTime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CourtSentenceNumber",
                table: "CorruptionRecords",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CourtSentenceDate",
                table: "CorruptionRecords",
                type: "DateTime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CourtSentenceApplyingDate",
                table: "CorruptionRecords",
                type: "DateTime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CourtCaseNumber",
                table: "CorruptionRecords",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "AspNetUsers",
                type: "DateTimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);
        }
    }
}
