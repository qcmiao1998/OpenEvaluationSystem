using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenEvaluation.Migrations
{
    public partial class ModifyScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeworkScores_Users_SubmitterUserUserId",
                table: "HomeworkScores");

            migrationBuilder.DropIndex(
                name: "IX_HomeworkScores_SubmitterUserUserId",
                table: "HomeworkScores");

            migrationBuilder.DropColumn(
                name: "SubmitterUserUserId",
                table: "HomeworkScores");

            migrationBuilder.AddColumn<string>(
                name: "EvaluateUserUserId",
                table: "HomeworkScores",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkScores_EvaluateUserUserId",
                table: "HomeworkScores",
                column: "EvaluateUserUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeworkScores_Users_EvaluateUserUserId",
                table: "HomeworkScores",
                column: "EvaluateUserUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeworkScores_Users_EvaluateUserUserId",
                table: "HomeworkScores");

            migrationBuilder.DropIndex(
                name: "IX_HomeworkScores_EvaluateUserUserId",
                table: "HomeworkScores");

            migrationBuilder.DropColumn(
                name: "EvaluateUserUserId",
                table: "HomeworkScores");

            migrationBuilder.AddColumn<string>(
                name: "SubmitterUserUserId",
                table: "HomeworkScores",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkScores_SubmitterUserUserId",
                table: "HomeworkScores",
                column: "SubmitterUserUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeworkScores_Users_SubmitterUserUserId",
                table: "HomeworkScores",
                column: "SubmitterUserUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
