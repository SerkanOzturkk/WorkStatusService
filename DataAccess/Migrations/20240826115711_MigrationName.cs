using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "TeamLeaderId",
                table: "Teams",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskStatusId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TaskStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TeamLeaderId",
                table: "Teams",
                column: "TeamLeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskStatusId",
                table: "Tasks",
                column: "TaskStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskStatuses_TaskStatusId",
                table: "Tasks",
                column: "TaskStatusId",
                principalTable: "TaskStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Employees_TeamLeaderId",
                table: "Teams",
                column: "TeamLeaderId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskStatuses_TaskStatusId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Employees_TeamLeaderId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "TaskStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Teams_TeamLeaderId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TaskStatusId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TeamLeaderId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TaskStatusId",
                table: "Tasks");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
