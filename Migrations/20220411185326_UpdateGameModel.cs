using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameLibraryApi.Migrations
{
    public partial class UpdateGameModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Games");

            migrationBuilder.AddColumn<string>(
                name: "Identifier",
                table: "Games",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "Identifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Identifier",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "Id");
        }
    }
}
