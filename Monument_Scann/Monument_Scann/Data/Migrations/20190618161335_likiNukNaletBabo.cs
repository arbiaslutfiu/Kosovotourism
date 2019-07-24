using Microsoft.EntityFrameworkCore.Migrations;

namespace Monument_Scann.Data.Migrations
{
    public partial class likiNukNaletBabo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lajkis_touristspot_touristspotsId",
                table: "Lajkis");

            migrationBuilder.DropIndex(
                name: "IX_Lajkis_touristspotsId",
                table: "Lajkis");

            migrationBuilder.DropColumn(
                name: "touristspotsId",
                table: "Lajkis");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "touristspotsId",
                table: "Lajkis",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Lajkis_touristspotsId",
                table: "Lajkis",
                column: "touristspotsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lajkis_touristspot_touristspotsId",
                table: "Lajkis",
                column: "touristspotsId",
                principalTable: "touristspot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
