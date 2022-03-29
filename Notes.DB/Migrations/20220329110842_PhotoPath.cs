using Microsoft.EntityFrameworkCore.Migrations;

namespace BeMyTeacher.DB.Migrations
{
    public partial class PhotoPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "TutoringAds",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "TutoringAds");
        }
    }
}
