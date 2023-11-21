using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskTrackerApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForTodo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "TaskTodoId", "TaskTodoDate", "TaskTodoDescription", "TaskTodoName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 22, 11, 41, 53, 751, DateTimeKind.Local).AddTicks(6805), "Finish the web application project", "Complete Project" },
                    { 2, new DateTime(2023, 11, 23, 11, 41, 53, 751, DateTimeKind.Local).AddTicks(6819), "Read a new book on software development", "Read Book" },
                    { 3, new DateTime(2023, 11, 24, 11, 41, 53, 751, DateTimeKind.Local).AddTicks(6820), "Go for a run or hit the gym", "Exercise" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "TaskTodoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "TaskTodoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "TaskTodoId",
                keyValue: 3);
        }
    }
}
