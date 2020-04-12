using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenEvaluation.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<string>(nullable: false),
                    GroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "HomeworkContents",
                columns: table => new
                {
                    HomeworkContentId = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeworkContents", x => x.HomeworkContentId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    GroupId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Homeworks",
                columns: table => new
                {
                    HomeworkId = table.Column<string>(nullable: false),
                    OwnerUserId = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homeworks", x => x.HomeworkId);
                    table.ForeignKey(
                        name: "FK_Homeworks_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HomeworkScoreItems",
                columns: table => new
                {
                    HomeworkScoreItemId = table.Column<string>(nullable: false),
                    MinScore = table.Column<double>(nullable: false),
                    MaxScore = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    HomeworkId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeworkScoreItems", x => x.HomeworkScoreItemId);
                    table.ForeignKey(
                        name: "FK_HomeworkScoreItems_Homeworks_HomeworkId",
                        column: x => x.HomeworkId,
                        principalTable: "Homeworks",
                        principalColumn: "HomeworkId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HomeworkSubmits",
                columns: table => new
                {
                    HomeworkSubmitId = table.Column<string>(nullable: false),
                    SubmitType = table.Column<int>(nullable: false),
                    ScoreType = table.Column<int>(nullable: false),
                    SubmitterUserUserId = table.Column<string>(nullable: true),
                    SubmitterGroupGroupId = table.Column<string>(nullable: true),
                    ContentHomeworkContentId = table.Column<string>(nullable: true),
                    HomeworkId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeworkSubmits", x => x.HomeworkSubmitId);
                    table.ForeignKey(
                        name: "FK_HomeworkSubmits_HomeworkContents_ContentHomeworkContentId",
                        column: x => x.ContentHomeworkContentId,
                        principalTable: "HomeworkContents",
                        principalColumn: "HomeworkContentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeworkSubmits_Homeworks_HomeworkId",
                        column: x => x.HomeworkId,
                        principalTable: "Homeworks",
                        principalColumn: "HomeworkId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeworkSubmits_Groups_SubmitterGroupGroupId",
                        column: x => x.SubmitterGroupGroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeworkSubmits_Users_SubmitterUserUserId",
                        column: x => x.SubmitterUserUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HomeworkScores",
                columns: table => new
                {
                    HomeworkScoreId = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    SubmitterUserUserId = table.Column<string>(nullable: true),
                    SubmitterGroupGroupId = table.Column<string>(nullable: true),
                    ScoreItemHomeworkScoreItemId = table.Column<string>(nullable: true),
                    Score = table.Column<double>(nullable: false),
                    HomeworkSubmitId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeworkScores", x => x.HomeworkScoreId);
                    table.ForeignKey(
                        name: "FK_HomeworkScores_HomeworkSubmits_HomeworkSubmitId",
                        column: x => x.HomeworkSubmitId,
                        principalTable: "HomeworkSubmits",
                        principalColumn: "HomeworkSubmitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeworkScores_HomeworkScoreItems_ScoreItemHomeworkScoreItemId",
                        column: x => x.ScoreItemHomeworkScoreItemId,
                        principalTable: "HomeworkScoreItems",
                        principalColumn: "HomeworkScoreItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeworkScores_Groups_SubmitterGroupGroupId",
                        column: x => x.SubmitterGroupGroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeworkScores_Users_SubmitterUserUserId",
                        column: x => x.SubmitterUserUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_OwnerUserId",
                table: "Homeworks",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkScoreItems_HomeworkId",
                table: "HomeworkScoreItems",
                column: "HomeworkId");

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

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkScores_SubmitterUserUserId",
                table: "HomeworkScores",
                column: "SubmitterUserUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkSubmits_ContentHomeworkContentId",
                table: "HomeworkSubmits",
                column: "ContentHomeworkContentId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkSubmits_HomeworkId",
                table: "HomeworkSubmits",
                column: "HomeworkId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkSubmits_SubmitterGroupGroupId",
                table: "HomeworkSubmits",
                column: "SubmitterGroupGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkSubmits_SubmitterUserUserId",
                table: "HomeworkSubmits",
                column: "SubmitterUserUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupId",
                table: "Users",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeworkScores");

            migrationBuilder.DropTable(
                name: "HomeworkSubmits");

            migrationBuilder.DropTable(
                name: "HomeworkScoreItems");

            migrationBuilder.DropTable(
                name: "HomeworkContents");

            migrationBuilder.DropTable(
                name: "Homeworks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
