using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FocusFlow.Migrations
{
    /// <inheritdoc />
    public partial class addTasksTableAndSeedWithSampleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Importance = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskId", "CreatedAt", "Deadline", "Description", "Importance", "Name", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 23, 21, 8, 13, 387, DateTimeKind.Local).AddTicks(369), new DateTime(2024, 3, 30, 21, 8, 13, 387, DateTimeKind.Local).AddTicks(413), "Create a responsive design for the homepage", 1, "Design Homepage", 0, "1ebdc38a-a0ce-491d-a1fd-22c2ea0bd598" },
                    { 2, new DateTime(2024, 3, 23, 21, 8, 13, 387, DateTimeKind.Local).AddTicks(418), new DateTime(2024, 3, 26, 21, 8, 13, 387, DateTimeKind.Local).AddTicks(419), "Migrate the existing database to the new server", 2, "Database Migration", 0, "1ebdc38a-a0ce-491d-a1fd-22c2ea0bd598" },
                    { 3, new DateTime(2024, 3, 23, 21, 8, 13, 387, DateTimeKind.Local).AddTicks(421), new DateTime(2024, 4, 4, 21, 8, 13, 387, DateTimeKind.Local).AddTicks(422), "Fix the reported bugs in the user management module", 0, "Bug Fixing", 0, "1ebdc38a-a0ce-491d-a1fd-22c2ea0bd598" },
                    { 4, new DateTime(2024, 3, 23, 21, 8, 13, 387, DateTimeKind.Local).AddTicks(424), new DateTime(2024, 4, 2, 21, 8, 13, 387, DateTimeKind.Local).AddTicks(424), "Integrate the payment gateway API", 0, "API Integration", 0, "2691dfbb-9544-4aed-8893-b3b19f6d2af1" },
                    { 5, new DateTime(2024, 3, 23, 21, 8, 13, 387, DateTimeKind.Local).AddTicks(426), new DateTime(2024, 3, 24, 21, 8, 13, 387, DateTimeKind.Local).AddTicks(427), "Conduct performance testing on the new release", 1, "Performance Testing", 0, "2691dfbb-9544-4aed-8893-b3b19f6d2af1" },
                    { 6, new DateTime(2024, 3, 23, 21, 8, 13, 387, DateTimeKind.Local).AddTicks(429), new DateTime(2024, 4, 6, 21, 8, 13, 387, DateTimeKind.Local).AddTicks(430), "Review the code of the new features", 2, "Code Review", 0, "2691dfbb-9544-4aed-8893-b3b19f6d2af1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
