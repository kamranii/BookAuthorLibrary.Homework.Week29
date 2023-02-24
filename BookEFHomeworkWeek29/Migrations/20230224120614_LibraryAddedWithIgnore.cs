using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookEFHomeworkWeek29.Migrations
{
    public partial class LibraryAddedWithIgnore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "myschema");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Books",
                newSchema: "myschema");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "Authors",
                newSchema: "myschema");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                schema: "myschema",
                table: "Authors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                schema: "myschema",
                table: "Authors");

            migrationBuilder.RenameTable(
                name: "Books",
                schema: "myschema",
                newName: "Books");

            migrationBuilder.RenameTable(
                name: "Authors",
                schema: "myschema",
                newName: "Authors");
        }
    }
}
