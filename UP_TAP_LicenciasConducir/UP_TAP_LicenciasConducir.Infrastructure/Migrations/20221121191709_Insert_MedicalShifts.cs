using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UP_TAP_LicenciasConducir.Infrastructure.Migrations
{
    public partial class Insert_MedicalShifts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RevisionDate",
                table: "MedicalRevisions");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPassed",
                table: "MedicalRevisions",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateTable(
                name: "MedicalShifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MedicalRevisionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalShifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalShifts_MedicalRevisions_MedicalRevisionId",
                        column: x => x.MedicalRevisionId,
                        principalTable: "MedicalRevisions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalShifts_MedicalRevisionId",
                table: "MedicalShifts",
                column: "MedicalRevisionId",
                unique: true,
                filter: "[MedicalRevisionId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalShifts");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPassed",
                table: "MedicalRevisions",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RevisionDate",
                table: "MedicalRevisions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
