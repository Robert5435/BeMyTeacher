using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeMyTeacher.DB.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Califications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Califications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationLevels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PhotoPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TutoringAds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    EducationLevelId = table.Column<int>(nullable: false),
                    CalificationId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    AvailabilityOnline = table.Column<bool>(nullable: false),
                    AvailabilityHome = table.Column<bool>(nullable: false),
                    AvailabilityStudentHome = table.Column<bool>(nullable: false),
                    PricePerSession = table.Column<int>(nullable: false),
                    SessionLenghtinMinutes = table.Column<int>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutoringAds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TutoringAds_Califications_CalificationId",
                        column: x => x.CalificationId,
                        principalTable: "Califications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TutoringAds_EducationLevels_EducationLevelId",
                        column: x => x.EducationLevelId,
                        principalTable: "EducationLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TutoringAds_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TutoringAds_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TutoringAds_CalificationId",
                table: "TutoringAds",
                column: "CalificationId");

            migrationBuilder.CreateIndex(
                name: "IX_TutoringAds_EducationLevelId",
                table: "TutoringAds",
                column: "EducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_TutoringAds_LocationId",
                table: "TutoringAds",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_TutoringAds_SubjectId",
                table: "TutoringAds",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TutoringAds");

            migrationBuilder.DropTable(
                name: "Califications");

            migrationBuilder.DropTable(
                name: "EducationLevels");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
