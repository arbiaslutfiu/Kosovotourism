using Microsoft.EntityFrameworkCore.Migrations;

namespace Monument_Scann.Data.Migrations
{
    public partial class try13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lajki_Monument_MonumentsId",
                table: "Lajki");

            migrationBuilder.DropForeignKey(
                name: "FK_Lajki_touristspot_touristspotsId",
                table: "Lajki");

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

            migrationBuilder.RenameIndex(
                name: "IX_Lajki_touristspotsId",
                table: "Lajkis",
                newName: "IX_Lajkis_touristspotsId");

            migrationBuilder.RenameIndex(
                name: "IX_Lajki_MonumentsId",
                table: "Lajkis",
                newName: "IX_Lajkis_MonumentsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lajkis",
                table: "Lajkis",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lajkis_Monument_MonumentsId",
                table: "Lajkis",
                column: "MonumentsId",
                principalTable: "Monument",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lajkis_touristspot_touristspotsId",
                table: "Lajkis",
                column: "touristspotsId",
                principalTable: "touristspot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Lajkis_Monument_MonumentsId",
                table: "Lajkis");

            migrationBuilder.DropForeignKey(
                name: "FK_Lajkis_touristspot_touristspotsId",
                table: "Lajkis");

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

            migrationBuilder.RenameIndex(
                name: "IX_Lajkis_touristspotsId",
                table: "Lajki",
                newName: "IX_Lajki_touristspotsId");

            migrationBuilder.RenameIndex(
                name: "IX_Lajkis_MonumentsId",
                table: "Lajki",
                newName: "IX_Lajki_MonumentsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lajki",
                table: "Lajki",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lajki_Monument_MonumentsId",
                table: "Lajki",
                column: "MonumentsId",
                principalTable: "Monument",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lajki_touristspot_touristspotsId",
                table: "Lajki",
                column: "touristspotsId",
                principalTable: "touristspot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
