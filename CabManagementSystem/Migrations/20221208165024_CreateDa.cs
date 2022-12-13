using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CabManagementSystem.Migrations
{
    public partial class CreateDa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Drivers",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Drivers");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Drivers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "BooksId",
                table: "Book",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drivers",
                table: "Drivers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Book_BooksId",
                table: "Book",
                column: "BooksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_AspNetUsers_BooksId",
                table: "Book",
                column: "BooksId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_AspNetUsers_BooksId",
                table: "Book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drivers",
                table: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Book_BooksId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "BooksId",
                table: "Book");

            migrationBuilder.AddColumn<string>(
                name: "DriverId",
                table: "Drivers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drivers",
                table: "Drivers",
                column: "DriverId");
        }
    }
}
