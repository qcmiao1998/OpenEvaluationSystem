using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenEvaluation.Migrations
{
    public partial class UpdateHomework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScoreType",
                table: "HomeworkSubmits");

            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "Homeworks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Homeworks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeworkName",
                table: "Homeworks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "HomeworkName",
                table: "Homeworks");

            migrationBuilder.AddColumn<int>(
                name: "ScoreType",
                table: "HomeworkSubmits",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
