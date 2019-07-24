using Microsoft.EntityFrameworkCore.Migrations;

namespace Monument_Scann.Data.Migrations
{
    public partial class trying3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monument_Lajkis_LajkiMId",
                table: "Monument");

            migrationBuilder.DropForeignKey(
                name: "FK_touristspot_Lajkis_LajkiTSId",
                table: "touristspot");

            migrationBuilder.DropIndex(
                name: "IX_touristspot_LajkiTSId",
                table: "touristspot");

            migrationBuilder.DropIndex(
                name: "IX_Monument_LajkiMId",
                table: "Monument");

            migrationBuilder.DropColumn(
                name: "LajkiMmId",
                table: "Monument");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monument_Lajkis_LajkiMId",
                table: "Monument");

            migrationBuilder.DropForeignKey(
                name: "FK_touristspot_Lajkis_LajkiTSId",
                table: "touristspot");

            migrationBuilder.DropIndex(
                name: "IX_touristspot_LajkiTSId",
                table: "touristspot");

            migrationBuilder.DropIndex(
                name: "IX_Monument_LajkiMId",
                table: "Monument");

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
                name: "LajkiMmId",
                table: "Monument",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_touristspot_LajkiTSId",
                table: "touristspot",
                column: "LajkiTSId");

            migrationBuilder.CreateIndex(
                name: "IX_Monument_LajkiMId",
                table: "Monument",
                column: "LajkiMId");

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
    }
}
