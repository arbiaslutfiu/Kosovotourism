using Microsoft.EntityFrameworkCore.Migrations;

namespace Monument_Scann.Data.Migrations
{
    public partial class LiatDBset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monument_Lajki_LajkiMId",
                table: "Monument");

            migrationBuilder.DropForeignKey(
                name: "FK_touristspot_Lajki_LajkiTSId",
                table: "touristspot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lajki",
                table: "Lajki");

            migrationBuilder.RenameTable(
                name: "Lajki",
                newName: "Lajkis");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lajkis",
                table: "Lajkis",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Monument_Lajkis_LajkiMId",
                table: "Monument",
                column: "LajkiMId",
                principalTable: "Lajkis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_touristspot_Lajkis_LajkiTSId",
                table: "touristspot",
                column: "LajkiTSId",
                principalTable: "Lajkis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monument_Lajkis_LajkiMId",
                table: "Monument");

            migrationBuilder.DropForeignKey(
                name: "FK_touristspot_Lajkis_LajkiTSId",
                table: "touristspot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lajkis",
                table: "Lajkis");

            migrationBuilder.RenameTable(
                name: "Lajkis",
                newName: "Lajki");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lajki",
                table: "Lajki",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Monument_Lajki_LajkiMId",
                table: "Monument",
                column: "LajkiMId",
                principalTable: "Lajki",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_touristspot_Lajki_LajkiTSId",
                table: "touristspot",
                column: "LajkiTSId",
                principalTable: "Lajki",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
