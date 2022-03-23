using Microsoft.EntityFrameworkCore.Migrations;

namespace MagazinZaDrehi.Data.Migrations
{
    public partial class Order1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Articuls",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Articuls");
        }
    }
}
