using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenEvaluation.Migrations
{
    public partial class RefactorHomeworkSubmission2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeworkSubmits_Groups_SubmitterGroupGroupId",
                table: "HomeworkSubmits");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeworkSubmits_Users_SubmitterUserUserId",
                table: "HomeworkSubmits");

            migrationBuilder.DropIndex(
                name: "IX_HomeworkSubmits_SubmitterGroupGroupId",
                table: "HomeworkSubmits");

            migrationBuilder.DropIndex(
                name: "IX_HomeworkSubmits_SubmitterUserUserId",
                table: "HomeworkSubmits");

            migrationBuilder.DropColumn(
                name: "SubmitType",
                table: "HomeworkSubmits");

            migrationBuilder.DropColumn(
                name: "SubmitterGroupGroupId",
                table: "HomeworkSubmits");

            migrationBuilder.DropColumn(
                name: "SubmitterUserUserId",
                table: "HomeworkSubmits");

            migrationBuilder.AddColumn<string>(
                name: "SubmitGroupGroupId",
                table: "HomeworkSubmits",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmitTime",
                table: "HomeworkSubmits",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SubmitUserUserId",
                table: "HomeworkSubmits",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkSubmits_SubmitGroupGroupId",
                table: "HomeworkSubmits",
                column: "SubmitGroupGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkSubmits_SubmitUserUserId",
                table: "HomeworkSubmits",
                column: "SubmitUserUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeworkSubmits_Groups_SubmitGroupGroupId",
                table: "HomeworkSubmits",
                column: "SubmitGroupGroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeworkSubmits_Users_SubmitUserUserId",
                table: "HomeworkSubmits",
                column: "SubmitUserUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeworkSubmits_Groups_SubmitGroupGroupId",
                table: "HomeworkSubmits");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeworkSubmits_Users_SubmitUserUserId",
                table: "HomeworkSubmits");

            migrationBuilder.DropIndex(
                name: "IX_HomeworkSubmits_SubmitGroupGroupId",
                table: "HomeworkSubmits");

            migrationBuilder.DropIndex(
                name: "IX_HomeworkSubmits_SubmitUserUserId",
                table: "HomeworkSubmits");

            migrationBuilder.DropColumn(
                name: "SubmitGroupGroupId",
                table: "HomeworkSubmits");

            migrationBuilder.DropColumn(
                name: "SubmitTime",
                table: "HomeworkSubmits");

            migrationBuilder.DropColumn(
                name: "SubmitUserUserId",
                table: "HomeworkSubmits");

            migrationBuilder.AddColumn<int>(
                name: "SubmitType",
                table: "HomeworkSubmits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SubmitterGroupGroupId",
                table: "HomeworkSubmits",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubmitterUserUserId",
                table: "HomeworkSubmits",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkSubmits_SubmitterGroupGroupId",
                table: "HomeworkSubmits",
                column: "SubmitterGroupGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkSubmits_SubmitterUserUserId",
                table: "HomeworkSubmits",
                column: "SubmitterUserUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeworkSubmits_Groups_SubmitterGroupGroupId",
                table: "HomeworkSubmits",
                column: "SubmitterGroupGroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeworkSubmits_Users_SubmitterUserUserId",
                table: "HomeworkSubmits",
                column: "SubmitterUserUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
