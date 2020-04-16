using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenEvaluation.Migrations
{
    public partial class RefactorHomeworkSubmission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeworkScores_HomeworkSubmits_HomeworkSubmitId",
                table: "HomeworkScores");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeworkScores_HomeworkScoreItems_ScoreItemHomeworkScoreItemId",
                table: "HomeworkScores");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeworkScores_Groups_SubmitterGroupGroupId",
                table: "HomeworkScores");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeworkSubmits_HomeworkContents_ContentHomeworkContentId",
                table: "HomeworkSubmits");

            migrationBuilder.DropTable(
                name: "HomeworkContents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HomeworkSubmits",
                table: "HomeworkSubmits");

            migrationBuilder.DropIndex(
                name: "IX_HomeworkSubmits_ContentHomeworkContentId",
                table: "HomeworkSubmits");

            migrationBuilder.DropIndex(
                name: "IX_HomeworkScores_HomeworkSubmitId",
                table: "HomeworkScores");

            migrationBuilder.DropIndex(
                name: "IX_HomeworkScores_ScoreItemHomeworkScoreItemId",
                table: "HomeworkScores");

            migrationBuilder.DropIndex(
                name: "IX_HomeworkScores_SubmitterGroupGroupId",
                table: "HomeworkScores");

            migrationBuilder.DropColumn(
                name: "HomeworkSubmitId",
                table: "HomeworkSubmits");

            migrationBuilder.DropColumn(
                name: "ContentHomeworkContentId",
                table: "HomeworkSubmits");

            migrationBuilder.DropColumn(
                name: "HomeworkSubmitId",
                table: "HomeworkScores");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "HomeworkScores");

            migrationBuilder.DropColumn(
                name: "ScoreItemHomeworkScoreItemId",
                table: "HomeworkScores");

            migrationBuilder.DropColumn(
                name: "SubmitterGroupGroupId",
                table: "HomeworkScores");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "HomeworkScores");

            migrationBuilder.AddColumn<string>(
                name: "HomeworkSubmissionId",
                table: "HomeworkSubmits",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "HomeworkSubmits",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "HomeworkSubmits",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HomeworkSubmissionId",
                table: "HomeworkScores",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomeworkSubmits",
                table: "HomeworkSubmits",
                column: "HomeworkSubmissionId");

            migrationBuilder.CreateTable(
                name: "SubScore",
                columns: table => new
                {
                    SubScoreId = table.Column<string>(nullable: false),
                    ScoreItemHomeworkScoreItemId = table.Column<string>(nullable: true),
                    Score = table.Column<double>(nullable: false),
                    HomeworkScoreId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubScore", x => x.SubScoreId);
                    table.ForeignKey(
                        name: "FK_SubScore_HomeworkScores_HomeworkScoreId",
                        column: x => x.HomeworkScoreId,
                        principalTable: "HomeworkScores",
                        principalColumn: "HomeworkScoreId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubScore_HomeworkScoreItems_ScoreItemHomeworkScoreItemId",
                        column: x => x.ScoreItemHomeworkScoreItemId,
                        principalTable: "HomeworkScoreItems",
                        principalColumn: "HomeworkScoreItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkScores_HomeworkSubmissionId",
                table: "HomeworkScores",
                column: "HomeworkSubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubScore_HomeworkScoreId",
                table: "SubScore",
                column: "HomeworkScoreId");

            migrationBuilder.CreateIndex(
                name: "IX_SubScore_ScoreItemHomeworkScoreItemId",
                table: "SubScore",
                column: "ScoreItemHomeworkScoreItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeworkScores_HomeworkSubmits_HomeworkSubmissionId",
                table: "HomeworkScores",
                column: "HomeworkSubmissionId",
                principalTable: "HomeworkSubmits",
                principalColumn: "HomeworkSubmissionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeworkScores_HomeworkSubmits_HomeworkSubmissionId",
                table: "HomeworkScores");

            migrationBuilder.DropTable(
                name: "SubScore");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HomeworkSubmits",
                table: "HomeworkSubmits");

            migrationBuilder.DropIndex(
                name: "IX_HomeworkScores_HomeworkSubmissionId",
                table: "HomeworkScores");

            migrationBuilder.DropColumn(
                name: "HomeworkSubmissionId",
                table: "HomeworkSubmits");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "HomeworkSubmits");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "HomeworkSubmits");

            migrationBuilder.DropColumn(
                name: "HomeworkSubmissionId",
                table: "HomeworkScores");

            migrationBuilder.AddColumn<string>(
                name: "HomeworkSubmitId",
                table: "HomeworkSubmits",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContentHomeworkContentId",
                table: "HomeworkSubmits",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeworkSubmitId",
                table: "HomeworkScores",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Score",
                table: "HomeworkScores",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "ScoreItemHomeworkScoreItemId",
                table: "HomeworkScores",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubmitterGroupGroupId",
                table: "HomeworkScores",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "HomeworkScores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomeworkSubmits",
                table: "HomeworkSubmits",
                column: "HomeworkSubmitId");

            migrationBuilder.CreateTable(
                name: "HomeworkContents",
                columns: table => new
                {
                    HomeworkContentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeworkContents", x => x.HomeworkContentId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkSubmits_ContentHomeworkContentId",
                table: "HomeworkSubmits",
                column: "ContentHomeworkContentId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkScores_HomeworkSubmitId",
                table: "HomeworkScores",
                column: "HomeworkSubmitId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkScores_ScoreItemHomeworkScoreItemId",
                table: "HomeworkScores",
                column: "ScoreItemHomeworkScoreItemId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkScores_SubmitterGroupGroupId",
                table: "HomeworkScores",
                column: "SubmitterGroupGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeworkScores_HomeworkSubmits_HomeworkSubmitId",
                table: "HomeworkScores",
                column: "HomeworkSubmitId",
                principalTable: "HomeworkSubmits",
                principalColumn: "HomeworkSubmitId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeworkScores_HomeworkScoreItems_ScoreItemHomeworkScoreItemId",
                table: "HomeworkScores",
                column: "ScoreItemHomeworkScoreItemId",
                principalTable: "HomeworkScoreItems",
                principalColumn: "HomeworkScoreItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeworkScores_Groups_SubmitterGroupGroupId",
                table: "HomeworkScores",
                column: "SubmitterGroupGroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeworkSubmits_HomeworkContents_ContentHomeworkContentId",
                table: "HomeworkSubmits",
                column: "ContentHomeworkContentId",
                principalTable: "HomeworkContents",
                principalColumn: "HomeworkContentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
