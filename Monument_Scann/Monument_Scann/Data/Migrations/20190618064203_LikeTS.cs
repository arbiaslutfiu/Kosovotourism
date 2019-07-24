using Microsoft.EntityFrameworkCore.Migrations;

namespace Monument_Scann.Data.Migrations
{
    public partial class LikeTS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_touristspot_Lajkis_LajkiTSId",
                table: "touristspot");

            migrationBuilder.DropIndex(
                name: "IX_touristspot_LajkiTSId",
                table: "touristspot");

            migrationBuilder.AlterColumn<int>(
                name: "LajkiTSId",
                table: "touristspot",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_touristspot_LajkiTSId",
                table: "touristspot",
                column: "LajkiTSId",
                unique: true);

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
                name: "FK_touristspot_Lajkis_LajkiTSId",
                table: "touristspot");

            migrationBuilder.DropIndex(
                name: "IX_touristspot_LajkiTSId",
                table: "touristspot");

            migrationBuilder.AlterColumn<int>(
                name: "LajkiTSId",
                table: "touristspot",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_touristspot_LajkiTSId",
                table: "touristspot",
                column: "LajkiTSId");

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
