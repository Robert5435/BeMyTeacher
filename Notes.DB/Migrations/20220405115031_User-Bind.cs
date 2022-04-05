using Microsoft.EntityFrameworkCore.Migrations;

namespace BeMyTeacher.DB.Migrations
{
    public partial class UserBind : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TutoringAds_UserId",
                table: "TutoringAds",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TutoringAds_Users_UserId",
                table: "TutoringAds",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TutoringAds_Users_UserId",
                table: "TutoringAds");

            migrationBuilder.DropIndex(
                name: "IX_TutoringAds_UserId",
                table: "TutoringAds");
        }
    }
}
