using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookEFHomeworkWeek29.Migrations
{
    public partial class UpdateAnnotations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "UX_Books_AuthorId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.AlterColumn<float>(
                name: "UnitPrice",
                table: "Books",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "AthrId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorId",
                table: "Books");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "Books",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<int>(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_FK_Books_Authors_AuthorId",
                table: "Books",
                column: "FK_Books_Authors_AuthorId");

            migrationBuilder.CreateIndex(
                name: "UX_Books_AuthorId",
                table: "Books",
                column: "AuthorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_FK_Books_Authors_AuthorId",
                table: "Books",
                column: "FK_Books_Authors_AuthorId",
                principalTable: "Authors",
                principalColumn: "AthrId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
