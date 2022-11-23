using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UP_TAP_LicenciasConducir.Infrastructure.Migrations
{
    public partial class Update_QuizQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestion_Answer_AnswerId",
                table: "QuizQuestion");

            migrationBuilder.AlterColumn<int>(
                name: "AnswerId",
                table: "QuizQuestion",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "QuizQuestion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestion_QuestionId",
                table: "QuizQuestion",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestion_Answer_AnswerId",
                table: "QuizQuestion",
                column: "AnswerId",
                principalTable: "Answer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestion_Questions_QuestionId",
                table: "QuizQuestion",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestion_Answer_AnswerId",
                table: "QuizQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestion_Questions_QuestionId",
                table: "QuizQuestion");

            migrationBuilder.DropIndex(
                name: "IX_QuizQuestion_QuestionId",
                table: "QuizQuestion");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "QuizQuestion");

            migrationBuilder.AlterColumn<int>(
                name: "AnswerId",
                table: "QuizQuestion",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestion_Answer_AnswerId",
                table: "QuizQuestion",
                column: "AnswerId",
                principalTable: "Answer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
