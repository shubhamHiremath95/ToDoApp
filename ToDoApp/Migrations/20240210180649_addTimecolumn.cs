using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoAPP.Migrations
{
    /// <inheritdoc />
    public partial class addTimecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_toDoItems",
                table: "toDoItems");

            migrationBuilder.RenameTable(
                name: "toDoItems",
                newName: "ToDoItems");

            migrationBuilder.AddColumn<TimeOnly>(
                name: "Time",
                table: "ToDoItems",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDoItems",
                table: "ToDoItems",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDoItems",
                table: "ToDoItems");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "ToDoItems");

            migrationBuilder.RenameTable(
                name: "ToDoItems",
                newName: "toDoItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_toDoItems",
                table: "toDoItems",
                column: "Id");
        }
    }
}
