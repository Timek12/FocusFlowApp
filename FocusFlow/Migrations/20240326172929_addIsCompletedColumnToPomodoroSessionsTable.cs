using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FocusFlow.Migrations
{
    /// <inheritdoc />
    public partial class addIsCompletedColumnToPomodoroSessionsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isCompleted",
                table: "PomodoroSessions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2024, 3, 26, 18, 29, 29, 723, DateTimeKind.Local).AddTicks(6829), new DateTime(2024, 4, 2, 18, 29, 29, 723, DateTimeKind.Local).AddTicks(6872) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2024, 3, 26, 18, 29, 29, 723, DateTimeKind.Local).AddTicks(6877), new DateTime(2024, 3, 29, 18, 29, 29, 723, DateTimeKind.Local).AddTicks(6878) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2024, 3, 26, 18, 29, 29, 723, DateTimeKind.Local).AddTicks(6880), new DateTime(2024, 4, 7, 18, 29, 29, 723, DateTimeKind.Local).AddTicks(6881) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2024, 3, 26, 18, 29, 29, 723, DateTimeKind.Local).AddTicks(6883), new DateTime(2024, 4, 5, 18, 29, 29, 723, DateTimeKind.Local).AddTicks(6883) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2024, 3, 26, 18, 29, 29, 723, DateTimeKind.Local).AddTicks(6885), new DateTime(2024, 3, 27, 18, 29, 29, 723, DateTimeKind.Local).AddTicks(6886) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2024, 3, 26, 18, 29, 29, 723, DateTimeKind.Local).AddTicks(6888), new DateTime(2024, 4, 9, 18, 29, 29, 723, DateTimeKind.Local).AddTicks(6889) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isCompleted",
                table: "PomodoroSessions");

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
        }
    }
}
