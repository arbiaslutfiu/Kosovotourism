using Microsoft.EntityFrameworkCore.Migrations;

namespace Monument_Scann.Data.Migrations
{
    public partial class forinkeyTuristComents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TouristSpotComents_touristspotId",
                table: "TouristSpotComents");

            migrationBuilder.AddColumn<int>(
                name: "ComentsId",
                table: "touristspot",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TouristSpotComents_touristspotId",
                table: "TouristSpotComents",
                column: "touristspotId");

            migrationBuilder.CreateIndex(
                name: "IX_touristspot_ComentsId",
                table: "touristspot",
                column: "ComentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_touristspot_TouristSpotComents_ComentsId",
                table: "touristspot",
                column: "ComentsId",
                principalTable: "TouristSpotComents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_touristspot_TouristSpotComents_ComentsId",
                table: "touristspot");

            migrationBuilder.DropIndex(
                name: "IX_TouristSpotComents_touristspotId",
                table: "TouristSpotComents");

            migrationBuilder.DropIndex(
                name: "IX_touristspot_ComentsId",
                table: "touristspot");

            migrationBuilder.DropColumn(
                name: "ComentsId",
                table: "touristspot");

            migrationBuilder.CreateIndex(
                name: "IX_TouristSpotComents_touristspotId",
                table: "TouristSpotComents",
                column: "touristspotId",
                unique: true);
        }
    }
}
