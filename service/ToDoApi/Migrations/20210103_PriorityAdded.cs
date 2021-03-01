using System;
using Microsoft.EntityFrameworkCore.Migrations;
// here we added to build a priotity for task
namespace ToDoApi.Migrations
{
    public partial class Priorityadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "ToDoItems",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "NORMAL");

            migrationBuilder.UpdateData(
               table: "ToDoItems",
               keyColumn: "Id",
               keyValue: new Guid("35BBEF83-2B66-4D94-B1B6-075B5172868F"),
               column: "Priority",
               value: "HIGH");


            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: new Guid("38560f1d-83aa-4824-a39d-f81b2ac4ae81"),
                column: "Priority",
                value: "NORMAL");

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: new Guid("cc552a5d-a3e4-4e5e-bcb0-3ec3d249a3f9"),
                column: "Priority",
                value: "NORMAL");

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: new Guid("cf185182-88c1-4413-969d-733cea151b1a"),
                column: "Priority",
                value: "NORMAL");

            migrationBuilder.UpdateData(
              table: "ToDoItems",
              keyColumn: "Id",
              keyValue: new Guid("EB60226C-F9A0-44FC-887C-EC98CE39F433"),
              column: "Priority",
              value: "HIGH");

            migrationBuilder.UpdateData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: new Guid("e404faa1-7a06-41d2-87b8-7ddfb9e7300c"),
                column: "Priority",
                value: "LOW");

            migrationBuilder.UpdateData(
             table: "ToDoItems",
             keyColumn: "Id",
             keyValue: new Guid("AD35676C-81A0-48C3-8AF6-4D8DD41671F0"),
             column: "Priority",
             value: "HIGH");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "ToDoItems");
        }
    }
}
