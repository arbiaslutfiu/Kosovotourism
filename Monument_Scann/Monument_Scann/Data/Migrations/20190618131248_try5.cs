using Microsoft.EntityFrameworkCore.Migrations;

namespace Monument_Scann.Data.Migrations
{
    public partial class try5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_touristspot_LajkiTSId",
                table: "touristspot");

            migrationBuilder.DropIndex(
                name: "IX_Monument_LajkiMId",
                table: "Monument");

            migrationBuilder.AddColumn<int>(
                name: "MonumentId",
                table: "Lajkis",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "touristspotId",
                table: "Lajkis",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_touristspot_LajkiTSId",
                table: "touristspot",
                column: "LajkiTSId");

            migrationBuilder.CreateIndex(
                name: "IX_Monument_LajkiMId",
                table: "Monument",
                column: "LajkiMId");

            migrationBuilder.CreateIndex(
                name: "IX_Lajkis_MonumentId",
                table: "Lajkis",
                column: "MonumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Lajkis_touristspotId",
                table: "Lajkis",
                column: "touristspotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lajkis_Monument_MonumentId",
                table: "Lajkis",
                column: "MonumentId",
                principalTable: "Monument",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lajkis_touristspot_touristspotId",
                table: "Lajkis",
                column: "touristspotId",
                principalTable: "touristspot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lajkis_Monument_MonumentId",
                table: "Lajkis");

            migrationBuilder.DropForeignKey(
                name: "FK_Lajkis_touristspot_touristspotId",
                table: "Lajkis");

            migrationBuilder.DropIndex(
                name: "IX_touristspot_LajkiTSId",
                table: "touristspot");

            migrationBuilder.DropIndex(
                name: "IX_Monument_LajkiMId",
                table: "Monument");

            migrationBuilder.DropIndex(
                name: "IX_Lajkis_MonumentId",
                table: "Lajkis");

            migrationBuilder.DropIndex(
                name: "IX_Lajkis_touristspotId",
                table: "Lajkis");

            migrationBuilder.DropColumn(
                name: "MonumentId",
                table: "Lajkis");

            migrationBuilder.DropColumn(
                name: "touristspotId",
                table: "Lajkis");

            migrationBuilder.CreateIndex(
                name: "IX_touristspot_LajkiTSId",
                table: "touristspot",
                column: "LajkiTSId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Monument_LajkiMId",
                table: "Monument",
                column: "LajkiMId",
                unique: true);
        }
    }
}
