using Microsoft.EntityFrameworkCore.Migrations;

namespace Monument_Scann.Data.Migrations
{
    public partial class Try7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lajkis_Monument_MonumentId",
                table: "Lajkis");

            migrationBuilder.DropForeignKey(
                name: "FK_Lajkis_touristspot_touristspotId",
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

            migrationBuilder.RenameTable(
                name: "Lajkis",
                newName: "Lajki");

            migrationBuilder.AlterColumn<int>(
                name: "LajkiTSId",
                table: "touristspot",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "LajkiMId",
                table: "Monument",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "MonumentsId",
                table: "Lajki",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "touristspotsId",
                table: "Lajki",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lajki",
                table: "Lajki",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Lajki_MonumentsId",
                table: "Lajki",
                column: "MonumentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Lajki_touristspotsId",
                table: "Lajki",
                column: "touristspotsId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Lajki_MonumentsId",
                table: "Lajki");

            migrationBuilder.DropIndex(
                name: "IX_Lajki_touristspotsId",
                table: "Lajki");

            migrationBuilder.DropColumn(
                name: "MonumentsId",
                table: "Lajki");

            migrationBuilder.DropColumn(
                name: "touristspotsId",
                table: "Lajki");

            migrationBuilder.RenameTable(
                name: "Lajki",
                newName: "Lajkis");

            migrationBuilder.AlterColumn<int>(
                name: "LajkiTSId",
                table: "touristspot",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LajkiMId",
                table: "Monument",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MonumentId",
                table: "Lajkis",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "touristspotId",
                table: "Lajkis",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lajkis",
                table: "Lajkis",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Monument_Lajkis_LajkiMId",
                table: "Monument",
                column: "LajkiMId",
                principalTable: "Lajkis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_touristspot_Lajkis_LajkiTSId",
                table: "touristspot",
                column: "LajkiTSId",
                principalTable: "Lajkis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
