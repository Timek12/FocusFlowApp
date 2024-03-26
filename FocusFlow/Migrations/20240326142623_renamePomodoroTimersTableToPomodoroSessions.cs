using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FocusFlow.Migrations
{
    /// <inheritdoc />
    public partial class renamePomodoroTimersTableToPomodoroSessions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PomodoroTimers_AspNetUsers_UserId",
                table: "PomodoroTimers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_PomodoroTimers_PomodoroSessionSessionId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PomodoroTimers",
                table: "PomodoroTimers");

            migrationBuilder.RenameTable(
                name: "PomodoroTimers",
                newName: "PomodoroSessions");

            migrationBuilder.RenameIndex(
                name: "IX_PomodoroTimers_UserId",
                table: "PomodoroSessions",
                newName: "IX_PomodoroSessions_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PomodoroSessions",
                table: "PomodoroSessions",
                column: "SessionId");

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2024, 3, 26, 15, 26, 23, 65, DateTimeKind.Local).AddTicks(7863), new DateTime(2024, 4, 2, 15, 26, 23, 65, DateTimeKind.Local).AddTicks(7907) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2024, 3, 26, 15, 26, 23, 65, DateTimeKind.Local).AddTicks(7912), new DateTime(2024, 3, 29, 15, 26, 23, 65, DateTimeKind.Local).AddTicks(7913) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2024, 3, 26, 15, 26, 23, 65, DateTimeKind.Local).AddTicks(7915), new DateTime(2024, 4, 7, 15, 26, 23, 65, DateTimeKind.Local).AddTicks(7916) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2024, 3, 26, 15, 26, 23, 65, DateTimeKind.Local).AddTicks(7918), new DateTime(2024, 4, 5, 15, 26, 23, 65, DateTimeKind.Local).AddTicks(7919) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2024, 3, 26, 15, 26, 23, 65, DateTimeKind.Local).AddTicks(7920), new DateTime(2024, 3, 27, 15, 26, 23, 65, DateTimeKind.Local).AddTicks(7921) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2024, 3, 26, 15, 26, 23, 65, DateTimeKind.Local).AddTicks(7923), new DateTime(2024, 4, 9, 15, 26, 23, 65, DateTimeKind.Local).AddTicks(7924) });

            migrationBuilder.AddForeignKey(
                name: "FK_PomodoroSessions_AspNetUsers_UserId",
                table: "PomodoroSessions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_PomodoroSessions_PomodoroSessionSessionId",
                table: "Tasks",
                column: "PomodoroSessionSessionId",
                principalTable: "PomodoroSessions",
                principalColumn: "SessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PomodoroSessions_AspNetUsers_UserId",
                table: "PomodoroSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_PomodoroSessions_PomodoroSessionSessionId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PomodoroSessions",
                table: "PomodoroSessions");

            migrationBuilder.RenameTable(
                name: "PomodoroSessions",
                newName: "PomodoroTimers");

            migrationBuilder.RenameIndex(
                name: "IX_PomodoroSessions_UserId",
                table: "PomodoroTimers",
                newName: "IX_PomodoroTimers_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PomodoroTimers",
                table: "PomodoroTimers",
                column: "SessionId");

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2024, 3, 26, 15, 10, 20, 887, DateTimeKind.Local).AddTicks(2010), new DateTime(2024, 4, 2, 15, 10, 20, 887, DateTimeKind.Local).AddTicks(2052) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2024, 3, 26, 15, 10, 20, 887, DateTimeKind.Local).AddTicks(2057), new DateTime(2024, 3, 29, 15, 10, 20, 887, DateTimeKind.Local).AddTicks(2058) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2024, 3, 26, 15, 10, 20, 887, DateTimeKind.Local).AddTicks(2060), new DateTime(2024, 4, 7, 15, 10, 20, 887, DateTimeKind.Local).AddTicks(2061) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2024, 3, 26, 15, 10, 20, 887, DateTimeKind.Local).AddTicks(2063), new DateTime(2024, 4, 5, 15, 10, 20, 887, DateTimeKind.Local).AddTicks(2064) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2024, 3, 26, 15, 10, 20, 887, DateTimeKind.Local).AddTicks(2065), new DateTime(2024, 3, 27, 15, 10, 20, 887, DateTimeKind.Local).AddTicks(2066) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2024, 3, 26, 15, 10, 20, 887, DateTimeKind.Local).AddTicks(2068), new DateTime(2024, 4, 9, 15, 10, 20, 887, DateTimeKind.Local).AddTicks(2069) });

            migrationBuilder.AddForeignKey(
                name: "FK_PomodoroTimers_AspNetUsers_UserId",
                table: "PomodoroTimers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_PomodoroTimers_PomodoroSessionSessionId",
                table: "Tasks",
                column: "PomodoroSessionSessionId",
                principalTable: "PomodoroTimers",
                principalColumn: "SessionId");
        }
    }
}
