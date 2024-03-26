using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FocusFlow.Migrations
{
    /// <inheritdoc />
    public partial class addPomodoroTimerTableAndAddNavigationPropertyInUserTaskTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PomodoroTimerId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PomodoroTimers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    BreakDuration = table.Column<TimeSpan>(type: "time", nullable: false),
                    isRunning = table.Column<bool>(type: "bit", nullable: false),
                    isBreak = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PomodoroTimers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Deadline", "PomodoroTimerId" },
                values: new object[] { new DateTime(2024, 3, 26, 1, 21, 4, 365, DateTimeKind.Local).AddTicks(3573), new DateTime(2024, 4, 2, 1, 21, 4, 365, DateTimeKind.Local).AddTicks(3625), null });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Deadline", "PomodoroTimerId" },
                values: new object[] { new DateTime(2024, 3, 26, 1, 21, 4, 365, DateTimeKind.Local).AddTicks(3632), new DateTime(2024, 3, 29, 1, 21, 4, 365, DateTimeKind.Local).AddTicks(3633), null });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Deadline", "PomodoroTimerId" },
                values: new object[] { new DateTime(2024, 3, 26, 1, 21, 4, 365, DateTimeKind.Local).AddTicks(3636), new DateTime(2024, 4, 7, 1, 21, 4, 365, DateTimeKind.Local).AddTicks(3638), null });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Deadline", "PomodoroTimerId" },
                values: new object[] { new DateTime(2024, 3, 26, 1, 21, 4, 365, DateTimeKind.Local).AddTicks(3640), new DateTime(2024, 4, 5, 1, 21, 4, 365, DateTimeKind.Local).AddTicks(3642), null });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Deadline", "PomodoroTimerId" },
                values: new object[] { new DateTime(2024, 3, 26, 1, 21, 4, 365, DateTimeKind.Local).AddTicks(3644), new DateTime(2024, 3, 27, 1, 21, 4, 365, DateTimeKind.Local).AddTicks(3646), null });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Deadline", "PomodoroTimerId" },
                values: new object[] { new DateTime(2024, 3, 26, 1, 21, 4, 365, DateTimeKind.Local).AddTicks(3649), new DateTime(2024, 4, 9, 1, 21, 4, 365, DateTimeKind.Local).AddTicks(3650), null });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_PomodoroTimerId",
                table: "Tasks",
                column: "PomodoroTimerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_PomodoroTimers_PomodoroTimerId",
                table: "Tasks",
                column: "PomodoroTimerId",
                principalTable: "PomodoroTimers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_PomodoroTimers_PomodoroTimerId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "PomodoroTimers");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_PomodoroTimerId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "PomodoroTimerId",
                table: "Tasks");

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2024, 3, 23, 21, 8, 13, 387, DateTimeKind.Local).AddTicks(369), new DateTime(2024, 3, 30, 21, 8, 13, 387, DateTimeKind.Local).AddTicks(413) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2024, 3, 23, 21, 8, 13, 387, DateTimeKind.Local).AddTicks(418), new DateTime(2024, 3, 26, 21, 8, 13, 387, DateTimeKind.Local).AddTicks(419) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2024, 3, 23, 21, 8, 13, 387, DateTimeKind.Local).AddTicks(421), new DateTime(2024, 4, 4, 21, 8, 13, 387, DateTimeKind.Local).AddTicks(422) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2024, 3, 23, 21, 8, 13, 387, DateTimeKind.Local).AddTicks(424), new DateTime(2024, 4, 2, 21, 8, 13, 387, DateTimeKind.Local).AddTicks(424) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2024, 3, 23, 21, 8, 13, 387, DateTimeKind.Local).AddTicks(426), new DateTime(2024, 3, 24, 21, 8, 13, 387, DateTimeKind.Local).AddTicks(427) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2024, 3, 23, 21, 8, 13, 387, DateTimeKind.Local).AddTicks(429), new DateTime(2024, 4, 6, 21, 8, 13, 387, DateTimeKind.Local).AddTicks(430) });
        }
    }
}
