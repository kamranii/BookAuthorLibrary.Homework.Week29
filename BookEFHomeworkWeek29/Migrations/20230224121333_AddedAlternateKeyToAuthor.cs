using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookEFHomeworkWeek29.Migrations
{
    public partial class AddedAlternateKeyToAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                schema: "myschema",
                table: "Authors",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Authors_Name_Surname",
                schema: "myschema",
                table: "Authors",
                columns: new[] { "Name", "Surname" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Authors_Name_Surname",
                schema: "myschema",
                table: "Authors");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                schema: "myschema",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
