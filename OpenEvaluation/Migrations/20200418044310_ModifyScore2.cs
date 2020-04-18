using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenEvaluation.Migrations
{
    public partial class ModifyScore2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HomeworkId",
                table: "HomeworkScores",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkScores_HomeworkId",
                table: "HomeworkScores",
                column: "HomeworkId");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeworkScores_Homeworks_HomeworkId",
                table: "HomeworkScores",
                column: "HomeworkId",
                principalTable: "Homeworks",
                principalColumn: "HomeworkId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeworkScores_Homeworks_HomeworkId",
                table: "HomeworkScores");

            migrationBuilder.DropIndex(
                name: "IX_HomeworkScores_HomeworkId",
                table: "HomeworkScores");

            migrationBuilder.DropColumn(
                name: "HomeworkId",
                table: "HomeworkScores");
        }
    }
}
