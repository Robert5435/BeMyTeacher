using Microsoft.EntityFrameworkCore.Migrations;

namespace BeMyTeacher.DB.Migrations
{
    public partial class UserRatingCounter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RatingCounter",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RatingUser",
                table: "Users",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RatingCounter",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RatingUser",
                table: "Users");
        }
    }
}
