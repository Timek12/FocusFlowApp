using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FocusFlow.Migrations
{
    /// <inheritdoc />
    public partial class createPomodoroSessionTableAndAddRelationInUSerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PomodoroSessionSessionId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PomodoroTimers",
                columns: table => new
                {
                    SessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    BreakDuration = table.Column<TimeSpan>(type: "time", nullable: false),
                    isRunning = table.Column<bool>(type: "bit", nullable: false),
                    isBreak = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PomodoroTimers", x => x.SessionId);
                    table.ForeignKey(
                        name: "FK_PomodoroTimers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Deadline", "PomodoroSessionSessionId" },
                values: new object[] { new DateTime(2024, 3, 26, 15, 10, 20, 887, DateTimeKind.Local).AddTicks(2010), new DateTime(2024, 4, 2, 15, 10, 20, 887, DateTimeKind.Local).AddTicks(2052), null });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Deadline", "PomodoroSessionSessionId" },
                values: new object[] { new DateTime(2024, 3, 26, 15, 10, 20, 887, DateTimeKind.Local).AddTicks(2057), new DateTime(2024, 3, 29, 15, 10, 20, 887, DateTimeKind.Local).AddTicks(2058), null });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Deadline", "PomodoroSessionSessionId" },
                values: new object[] { new DateTime(2024, 3, 26, 15, 10, 20, 887, DateTimeKind.Local).AddTicks(2060), new DateTime(2024, 4, 7, 15, 10, 20, 887, DateTimeKind.Local).AddTicks(2061), null });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Deadline", "PomodoroSessionSessionId" },
                values: new object[] { new DateTime(2024, 3, 26, 15, 10, 20, 887, DateTimeKind.Local).AddTicks(2063), new DateTime(2024, 4, 5, 15, 10, 20, 887, DateTimeKind.Local).AddTicks(2064), null });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Deadline", "PomodoroSessionSessionId" },
                values: new object[] { new DateTime(2024, 3, 26, 15, 10, 20, 887, DateTimeKind.Local).AddTicks(2065), new DateTime(2024, 3, 27, 15, 10, 20, 887, DateTimeKind.Local).AddTicks(2066), null });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Deadline", "PomodoroSessionSessionId" },
                values: new object[] { new DateTime(2024, 3, 26, 15, 10, 20, 887, DateTimeKind.Local).AddTicks(2068), new DateTime(2024, 4, 9, 15, 10, 20, 887, DateTimeKind.Local).AddTicks(2069), null });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_PomodoroSessionSessionId",
                table: "Tasks",
                column: "PomodoroSessionSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_PomodoroTimers_UserId",
                table: "PomodoroTimers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_PomodoroTimers_PomodoroSessionSessionId",
                table: "Tasks",
                column: "PomodoroSessionSessionId",
                principalTable: "PomodoroTimers",
                principalColumn: "SessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_PomodoroTimers_PomodoroSessionSessionId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "PomodoroTimers");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_PomodoroSessionSessionId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "PomodoroSessionSessionId",
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
