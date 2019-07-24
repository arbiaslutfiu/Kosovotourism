using Microsoft.EntityFrameworkCore.Migrations;

namespace Monument_Scann.Data.Migrations
{
    public partial class Try20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lajkis_Monument_MonumentsId",
                table: "Lajkis");

            migrationBuilder.DropForeignKey(
                name: "FK_Monument_Lajkis_LajkiMId",
                table: "Monument");

            migrationBuilder.AlterColumn<int>(
                name: "LajkiMId",
                table: "Monument",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MonumentsId",
                table: "Lajkis",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lajkis_Monument_MonumentsId",
                table: "Lajkis",
                column: "MonumentsId",
                principalTable: "Monument",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Monument_Lajkis_LajkiMId",
                table: "Monument",
                column: "LajkiMId",
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
                name: "FK_Monument_Lajkis_LajkiMId",
                table: "Monument");

            migrationBuilder.AlterColumn<int>(
                name: "LajkiMId",
                table: "Monument",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MonumentsId",
                table: "Lajkis",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Lajkis_Monument_MonumentsId",
                table: "Lajkis",
                column: "MonumentsId",
                principalTable: "Monument",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Monument_Lajkis_LajkiMId",
                table: "Monument",
                column: "LajkiMId",
                principalTable: "Lajkis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
